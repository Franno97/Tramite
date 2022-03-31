namespace Mre.Visas.Tramite.Application.Shared.Responses
{
    public abstract class BaseResponse
    {
        #region Constructors

        protected BaseResponse()
        {
        }

        protected BaseResponse(string id)
        {
            Id = id;
        }

        #endregion Constructors

        #region Properties

        public string Id { get; set; }

        #endregion Properties
    }
}