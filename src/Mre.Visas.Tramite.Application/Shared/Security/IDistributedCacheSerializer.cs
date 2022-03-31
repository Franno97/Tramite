using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.Security
{
    public interface IDistributedCacheSerializer
    {
        byte[] Serialize<T>(T obj);

        T Deserialize<T>(byte[] bytes);
    }


    public class Utf8JsonDistributedCacheSerializer : IDistributedCacheSerializer
    {

        public byte[] Serialize<T>(T obj)
        {

            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(obj);
            return jsonUtf8Bytes;

        }

        public T Deserialize<T>(byte[] bytes)
        {
            var readOnlySpan = new ReadOnlySpan<byte>(bytes);
            return (T)JsonSerializer.Deserialize(readOnlySpan, typeof(T));
        }
    }
}
