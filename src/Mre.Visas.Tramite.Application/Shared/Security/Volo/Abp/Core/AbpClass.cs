using IdentityModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tramite.Abp.Replica
{
    [Serializable]
    public class IdentityModelDiscoveryDocumentCacheItem
    {
        public string TokenEndpoint { get; set; }

        public string DeviceAuthorizationEndpoint { get; set; }

        public IdentityModelDiscoveryDocumentCacheItem()
        {

        }

        public IdentityModelDiscoveryDocumentCacheItem(string tokenEndpoint, string deviceAuthorizationEndpoint)
        {
            TokenEndpoint = tokenEndpoint;
            DeviceAuthorizationEndpoint = deviceAuthorizationEndpoint;
        }

        public static string CalculateCacheKey(IdentityClientConfiguration configuration)
        {
            return configuration.Authority.ToLower().ToMd5();
        }
    }


    [Serializable]
    public class IdentityModelTokenCacheItem
    {
        public string AccessToken { get; set; }

        public IdentityModelTokenCacheItem()
        {

        }

        public IdentityModelTokenCacheItem(string accessToken)
        {
            AccessToken = accessToken;
        }

        public static string CalculateCacheKey(IdentityClientConfiguration configuration)
        {
            return string.Join(",", configuration.Select(x => x.Key + ":" + x.Value)).ToMd5();
        }
    }

    public class AbpIdentityClientOptions
    {
        public IdentityClientConfigurationDictionary IdentityClients { get; set; }

        public AbpIdentityClientOptions()
        {
            IdentityClients = new IdentityClientConfigurationDictionary();
        }

        public IdentityClientConfiguration GetClientConfiguration(string identityClientName = null)
        {
            if (string.IsNullOrWhiteSpace(identityClientName))
            {
                identityClientName = IdentityClientConfigurationDictionary.DefaultName;
            }
             
            return IdentityClients.GetOrDefault(identityClientName) ??
                   IdentityClients.Default;
        }
    }


    public class IdentityClientConfigurationDictionary : Dictionary<string, IdentityClientConfiguration>
    {
        public const string DefaultName = "Default";

        public IdentityClientConfiguration Default
        {
            get => this.GetOrDefault(DefaultName);
            set => this[DefaultName] = value;
        }
    }

    public class IdentityClientConfiguration : Dictionary<string, string>
    {
        /// <summary>
        /// Possible values: "client_credentials" or "password".
        /// Default value: "client_credentials".
        /// </summary>
        public string GrantType
        {
            get => this.GetOrDefault(nameof(GrantType));
            set => this[nameof(GrantType)] = value;
        }

        /// <summary>
        /// Client Id.
        /// </summary>
        public string ClientId
        {
            get => this.GetOrDefault(nameof(ClientId));
            set => this[nameof(ClientId)] = value;
        }

        /// <summary>
        /// Client secret (as plain text - without hashed).
        /// </summary>
        public string ClientSecret
        {
            get => this.GetOrDefault(nameof(ClientSecret));
            set => this[nameof(ClientSecret)] = value;
        }

        /// <summary>
        /// User name.
        /// Valid only if <see cref="GrantType"/> is "password".
        /// </summary>
        public string UserName
        {
            get => this.GetOrDefault(nameof(UserName));
            set => this[nameof(UserName)] = value;
        }

        /// <summary>
        /// Password of the <see cref="UserName"/>.
        /// Valid only if <see cref="GrantType"/> is "password".
        /// </summary>
        public string UserPassword
        {
            get => this.GetOrDefault(nameof(UserPassword));
            set => this[nameof(UserPassword)] = value;
        }

        /// <summary>
        /// Authority.
        /// </summary>
        public string Authority
        {
            get => this.GetOrDefault(nameof(Authority));
            set => this[nameof(Authority)] = value;
        }

        /// <summary>
        /// Scope.
        /// </summary>
        public string Scope
        {
            get => this.GetOrDefault(nameof(Scope));
            set => this[nameof(Scope)] = value;
        }

        /// <summary>
        /// RequireHttps.
        /// Default: true.
        /// </summary>
        public bool RequireHttps
        {
            get => this.GetOrDefault(nameof(RequireHttps))?.To<bool>() ?? true;
            set => this[nameof(RequireHttps)] = value.ToString().ToLowerInvariant();
        }

        /// <summary>
        /// Absolute expiration duration (as seconds) for the access token cache.
        /// Default: 1800 seconds (30 minutes)
        /// </summary>
        public int CacheAbsoluteExpiration
        {
            get => this.GetOrDefault(nameof(CacheAbsoluteExpiration))?.To<int>() ?? 60 * 30;
            set => this[nameof(CacheAbsoluteExpiration)] = value.ToString(CultureInfo.InvariantCulture);
        }

        public IdentityClientConfiguration()
        {

        }

        public IdentityClientConfiguration(
            string authority,
            string scope,
            string clientId,
            string clientSecret,
            string grantType = OidcConstants.GrantTypes.ClientCredentials,
            string userName = null,
            string userPassword = null,
            bool requireHttps = true,
            int cacheAbsoluteExpiration = 60 * 30)
        {
            this[nameof(Authority)] = authority;
            this[nameof(Scope)] = scope;
            this[nameof(ClientId)] = clientId;
            this[nameof(ClientSecret)] = clientSecret;
            this[nameof(GrantType)] = grantType;
            this[nameof(UserName)] = userName;
            this[nameof(UserPassword)] = userPassword;
            this[nameof(RequireHttps)] = requireHttps.ToString().ToLowerInvariant();
            this[nameof(CacheAbsoluteExpiration)] = cacheAbsoluteExpiration.ToString(CultureInfo.InvariantCulture);
        }
    }


    /// <summary>
    /// Extension methods for Dictionary.
    /// </summary>
    internal static class AbpDictionaryExtensions
    {
        /// <summary>
        /// This method is used to try to get a value in a dictionary if it does exists.
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="dictionary">The collection object</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value of the key (or default value if key not exists)</param>
        /// <returns>True if key does exists in the dictionary</returns>
        internal static bool TryGetValue<T>(this IDictionary<string, object> dictionary, string key, out T value)
        {
            object valueObj;
            if (dictionary.TryGetValue(key, out valueObj) && valueObj is T)
            {
                value = (T)valueObj;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Gets a value from the dictionary with given key. Returns default value if can not find.
        /// </summary>
        /// <param name="dictionary">Dictionary to check and get</param>
        /// <param name="key">Key to find the value</param>
        /// <typeparam name="TKey">Type of the key</typeparam>
        /// <typeparam name="TValue">Type of the value</typeparam>
        /// <returns>Value if found, default if can not found.</returns>
        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue obj;
            return dictionary.TryGetValue(key, out obj) ? obj : default;
        }

        /// <summary>
        /// Gets a value from the dictionary with given key. Returns default value if can not find.
        /// </summary>
        /// <param name="dictionary">Dictionary to check and get</param>
        /// <param name="key">Key to find the value</param>
        /// <typeparam name="TKey">Type of the key</typeparam>
        /// <typeparam name="TValue">Type of the value</typeparam>
        /// <returns>Value if found, default if can not found.</returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGetValue(key, out var obj) ? obj : default;
        }

        /// <summary>
        /// Gets a value from the dictionary with given key. Returns default value if can not find.
        /// </summary>
        /// <param name="dictionary">Dictionary to check and get</param>
        /// <param name="key">Key to find the value</param>
        /// <typeparam name="TKey">Type of the key</typeparam>
        /// <typeparam name="TValue">Type of the value</typeparam>
        /// <returns>Value if found, default if can not found.</returns>
        public static TValue GetOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGetValue(key, out var obj) ? obj : default;
        }

        /// <summary>
        /// Gets a value from the dictionary with given key. Returns default value if can not find.
        /// </summary>
        /// <param name="dictionary">Dictionary to check and get</param>
        /// <param name="key">Key to find the value</param>
        /// <typeparam name="TKey">Type of the key</typeparam>
        /// <typeparam name="TValue">Type of the value</typeparam>
        /// <returns>Value if found, default if can not found.</returns>
        public static TValue GetOrDefault<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGetValue(key, out var obj) ? obj : default;
        }

        /// <summary>
        /// Gets a value from the dictionary with given key. Returns default value if can not find.
        /// </summary>
        /// <param name="dictionary">Dictionary to check and get</param>
        /// <param name="key">Key to find the value</param>
        /// <param name="factory">A factory method used to create the value if not found in the dictionary</param>
        /// <typeparam name="TKey">Type of the key</typeparam>
        /// <typeparam name="TValue">Type of the value</typeparam>
        /// <returns>Value if found, default if can not found.</returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory)
        {
            TValue obj;
            if (dictionary.TryGetValue(key, out obj))
            {
                return obj;
            }

            return dictionary[key] = factory(key);
        }

        /// <summary>
        /// Gets a value from the dictionary with given key. Returns default value if can not find.
        /// </summary>
        /// <param name="dictionary">Dictionary to check and get</param>
        /// <param name="key">Key to find the value</param>
        /// <param name="factory">A factory method used to create the value if not found in the dictionary</param>
        /// <typeparam name="TKey">Type of the key</typeparam>
        /// <typeparam name="TValue">Type of the value</typeparam>
        /// <returns>Value if found, default if can not found.</returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factory)
        {
            return dictionary.GetOrAdd(key, k => factory());
        }

        /// <summary>
        /// Gets a value from the concurrent dictionary with given key. Returns default value if can not find.
        /// </summary>
        /// <param name="dictionary">Concurrent dictionary to check and get</param>
        /// <param name="key">Key to find the value</param>
        /// <param name="factory">A factory method used to create the value if not found in the dictionary</param>
        /// <typeparam name="TKey">Type of the key</typeparam>
        /// <typeparam name="TValue">Type of the value</typeparam>
        /// <returns>Value if found, default if can not found.</returns>
        public static TValue GetOrAdd<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factory)
        {
            return dictionary.GetOrAdd(key, k => factory());
        }
    }


    /// <summary>
    /// Extension methods for all objects.
    /// </summary>
    internal static class AbpObjectExtensions
    {
        /// <summary>
        /// Used to simplify and beautify casting an object to a type.
        /// </summary>
        /// <typeparam name="T">Type to be casted</typeparam>
        /// <param name="obj">Object to cast</param>
        /// <returns>Casted object</returns>
        public static T As<T>(this object obj)
            where T : class
        {
            return (T)obj;
        }

        /// <summary>
        /// Converts given object to a value type using <see cref="Convert.ChangeType(object,System.Type)"/> method.
        /// </summary>
        /// <param name="obj">Object to be converted</param>
        /// <typeparam name="T">Type of the target object</typeparam>
        /// <returns>Converted object</returns>
        public static T To<T>(this object obj)
            where T : struct
        {
            if (typeof(T) == typeof(Guid))
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(obj.ToString());
            }

            return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Check if an item is in a list.
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <param name="list">List of items</param>
        /// <typeparam name="T">Type of the items</typeparam>
        public static bool IsIn<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }

        /// <summary>
        /// Check if an item is in the given enumerable.
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <param name="items">Items</param>
        /// <typeparam name="T">Type of the items</typeparam>
        public static bool IsIn<T>(this T item, IEnumerable<T> items)
        {
            return items.Contains(item);
        }

        /// <summary>
        /// Can be used to conditionally perform a function
        /// on an object and return the modified or the original object.
        /// It is useful for chained calls.
        /// </summary>
        /// <param name="obj">An object</param>
        /// <param name="condition">A condition</param>
        /// <param name="func">A function that is executed only if the condition is <code>true</code></param>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <returns>
        /// Returns the modified object (by the <paramref name="func"/> if the <paramref name="condition"/> is <code>true</code>)
        /// or the original object if the <paramref name="condition"/> is <code>false</code>
        /// </returns>
        public static T If<T>(this T obj, bool condition, Func<T, T> func)
        {
            if (condition)
            {
                return func(obj);
            }

            return obj;
        }

        /// <summary>
        /// Can be used to conditionally perform an action
        /// on an object and return the original object.
        /// It is useful for chained calls on the object.
        /// </summary>
        /// <param name="obj">An object</param>
        /// <param name="condition">A condition</param>
        /// <param name="action">An action that is executed only if the condition is <code>true</code></param>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <returns>
        /// Returns the original object.
        /// </returns>
        public static T If<T>(this T obj, bool condition, Action<T> action)
        {
            if (condition)
            {
                action(obj);
            }

            return obj;
        }
    }

    /// <summary>
    /// Extension methods for String class.
    /// </summary>
    internal static class AbpStringExtensions
    {
        /// <summary>
        /// Adds a char to end of given string if it does not ends with the char.
        /// </summary>
        public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType = StringComparison.Ordinal)
        {

            if (str.EndsWith(c.ToString(), comparisonType))
            {
                return str;
            }

            return str + c;
        }

        /// <summary>
        /// Adds a char to beginning of given string if it does not starts with the char.
        /// </summary>
        public static string EnsureStartsWith(this string str, char c, StringComparison comparisonType = StringComparison.Ordinal)
        {

            if (str.StartsWith(c.ToString(), comparisonType))
            {
                return str;
            }

            return c + str;
        }

        /// <summary>
        /// Indicates whether this string is null or an System.String.Empty string.
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// indicates whether this string is null, empty, or consists only of white-space characters.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="len"/> is bigger that string's length</exception>
        public static string Left(this string str, int len)
        {

            if (str.Length < len)
            {
                throw new ArgumentException("len argument can not be bigger than given string's length!");
            }

            return str.Substring(0, len);
        }

        /// <summary>
        /// Converts line endings in the string to <see cref="Environment.NewLine"/>.
        /// </summary>
        public static string NormalizeLineEndings(this string str)
        {
            return str.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine);
        }

        /// <summary>
        /// Gets index of nth occurrence of a char in a string.
        /// </summary>
        /// <param name="str">source string to be searched</param>
        /// <param name="c">Char to search in <paramref name="str"/></param>
        /// <param name="n">Count of the occurrence</param>
        public static int NthIndexOf(this string str, char c, int n)
        {

            var count = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] != c)
                {
                    continue;
                }

                if ((++count) == n)
                {
                    return i;
                }
            }

            return -1;
        }





        public static string ReplaceFirst(this string str, string search, string replace, StringComparison comparisonType = StringComparison.Ordinal)
        {

            var pos = str.IndexOf(search, comparisonType);
            if (pos < 0)
            {
                return str;
            }

            return str.Substring(0, pos) + replace + str.Substring(pos + search.Length);
        }

        /// <summary>
        /// Gets a substring of a string from end of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="len"/> is bigger that string's length</exception>
        public static string Right(this string str, int len)
        {

            if (str.Length < len)
            {
                throw new ArgumentException("len argument can not be bigger than given string's length!");
            }

            return str.Substring(str.Length - len, len);
        }

        /// <summary>
        /// Uses string.Split method to split given string by given separator.
        /// </summary>
        public static string[] Split(this string str, string separator)
        {
            return str.Split(new[] { separator }, StringSplitOptions.None);
        }

        /// <summary>
        /// Uses string.Split method to split given string by given separator.
        /// </summary>
        public static string[] Split(this string str, string separator, StringSplitOptions options)
        {
            return str.Split(new[] { separator }, options);
        }

        /// <summary>
        /// Uses string.Split method to split given string by <see cref="Environment.NewLine"/>.
        /// </summary>
        public static string[] SplitToLines(this string str)
        {
            return str.Split(Environment.NewLine);
        }

        /// <summary>
        /// Uses string.Split method to split given string by <see cref="Environment.NewLine"/>.
        /// </summary>
        public static string[] SplitToLines(this string str, StringSplitOptions options)
        {
            return str.Split(Environment.NewLine, options);
        }

        /// <summary>
        /// Converts PascalCase string to camelCase string.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="useCurrentCulture">set true to use current culture. Otherwise, invariant culture will be used.</param>
        /// <param name="handleAbbreviations">set true to if you want to convert 'XYZ' to 'xyz'.</param>
        /// <returns>camelCase of the string</returns>
        public static string ToCamelCase(this string str, bool useCurrentCulture = false, bool handleAbbreviations = false)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return useCurrentCulture ? str.ToLower() : str.ToLowerInvariant();
            }

            if (handleAbbreviations && IsAllUpperCase(str))
            {
                return useCurrentCulture ? str.ToLower() : str.ToLowerInvariant();
            }

            return (useCurrentCulture ? char.ToLower(str[0]) : char.ToLowerInvariant(str[0])) + str.Substring(1);
        }

        /// <summary>
        /// Converts given PascalCase/camelCase string to sentence (by splitting words by space).
        /// Example: "ThisIsSampleSentence" is converted to "This is a sample sentence".
        /// </summary>
        /// <param name="str">String to convert.</param>
        /// <param name="useCurrentCulture">set true to use current culture. Otherwise, invariant culture will be used.</param>
        public static string ToSentenceCase(this string str, bool useCurrentCulture = false)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return useCurrentCulture
                ? Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]))
                : Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLowerInvariant(m.Value[1]));
        }

        /// <summary>
        /// Converts given PascalCase/camelCase string to kebab-case.
        /// </summary>
        /// <param name="str">String to convert.</param>
        /// <param name="useCurrentCulture">set true to use current culture. Otherwise, invariant culture will be used.</param>
        public static string ToKebabCase(this string str, bool useCurrentCulture = false)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            str = str.ToCamelCase();

            return useCurrentCulture
                ? Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + "-" + char.ToLower(m.Value[1]))
                : Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + "-" + char.ToLowerInvariant(m.Value[1]));
        }

        /// <summary>
        /// Converts given PascalCase/camelCase string to snake case.
        /// Example: "ThisIsSampleSentence" is converted to "this_is_a_sample_sentence".
        /// https://github.com/npgsql/npgsql/blob/dev/src/Npgsql/NameTranslation/NpgsqlSnakeCaseNameTranslator.cs#L51
        /// </summary>
        /// <param name="str">String to convert.</param>
        /// <returns></returns>
        public static string ToSnakeCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            var builder = new StringBuilder(str.Length + Math.Min(2, str.Length / 5));
            var previousCategory = default(UnicodeCategory?);

            for (var currentIndex = 0; currentIndex < str.Length; currentIndex++)
            {
                var currentChar = str[currentIndex];
                if (currentChar == '_')
                {
                    builder.Append('_');
                    previousCategory = null;
                    continue;
                }

                var currentCategory = char.GetUnicodeCategory(currentChar);
                switch (currentCategory)
                {
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.TitlecaseLetter:
                        if (previousCategory == UnicodeCategory.SpaceSeparator ||
                            previousCategory == UnicodeCategory.LowercaseLetter ||
                            previousCategory != UnicodeCategory.DecimalDigitNumber &&
                            previousCategory != null &&
                            currentIndex > 0 &&
                            currentIndex + 1 < str.Length &&
                            char.IsLower(str[currentIndex + 1]))
                        {
                            builder.Append('_');
                        }

                        currentChar = char.ToLower(currentChar);
                        break;

                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        if (previousCategory == UnicodeCategory.SpaceSeparator)
                        {
                            builder.Append('_');
                        }
                        break;

                    default:
                        if (previousCategory != null)
                        {
                            previousCategory = UnicodeCategory.SpaceSeparator;
                        }
                        continue;
                }

                builder.Append(currentChar);
                previousCategory = currentCategory;
            }

            return builder.ToString();
        }

        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value)
            where T : struct
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <param name="ignoreCase">Ignore case</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value, bool ignoreCase)
            where T : struct
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        public static string ToMd5(this string str)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(str);
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                foreach (var hashByte in hashBytes)
                {
                    sb.Append(hashByte.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Converts camelCase string to PascalCase string.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="useCurrentCulture">set true to use current culture. Otherwise, invariant culture will be used.</param>
        /// <returns>PascalCase of the string</returns>
        public static string ToPascalCase(this string str, bool useCurrentCulture = false)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return useCurrentCulture ? str.ToUpper() : str.ToUpperInvariant();
            }

            return (useCurrentCulture ? char.ToUpper(str[0]) : char.ToUpperInvariant(str[0])) + str.Substring(1);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string Truncate(this string str, int maxLength)
        {
            if (str == null)
            {
                return null;
            }

            if (str.Length <= maxLength)
            {
                return str;
            }

            return str.Left(maxLength);
        }

        /// <summary>
        /// Gets a substring of a string from Ending of the string if it exceeds maximum length.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string TruncateFromBeginning(this string str, int maxLength)
        {
            if (str == null)
            {
                return null;
            }

            if (str.Length <= maxLength)
            {
                return str;
            }

            return str.Right(maxLength);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// It adds a "..." postfix to end of the string if it's truncated.
        /// Returning string can not be longer than maxLength.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string TruncateWithPostfix(this string str, int maxLength)
        {
            return TruncateWithPostfix(str, maxLength, "...");
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// It adds given <paramref name="postfix"/> to end of the string if it's truncated.
        /// Returning string can not be longer than maxLength.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string TruncateWithPostfix(this string str, int maxLength, string postfix)
        {
            if (str == null)
            {
                return null;
            }

            if (str == string.Empty || maxLength == 0)
            {
                return string.Empty;
            }

            if (str.Length <= maxLength)
            {
                return str;
            }

            if (maxLength <= postfix.Length)
            {
                return postfix.Left(maxLength);
            }

            return str.Left(maxLength - postfix.Length) + postfix;
        }

        /// <summary>
        /// Converts given string to a byte array using <see cref="Encoding.UTF8"/> encoding.
        /// </summary>
        public static byte[] GetBytes(this string str)
        {
            return str.GetBytes(Encoding.UTF8);
        }

        /// <summary>
        /// Converts given string to a byte array using the given <paramref name="encoding"/>
        /// </summary>
        public static byte[] GetBytes(this string str, Encoding encoding)
        {

            return encoding.GetBytes(str);
        }

        private static bool IsAllUpperCase(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
