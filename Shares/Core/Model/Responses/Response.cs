using Newtonsoft.Json;

namespace Core.Model.Responses
{
    public abstract class Response
    {

        #region Properties

        [JsonProperty(PropertyName = "errorCode", Required = Required.Default)]
        public int ErrorCode { get; set; } = 404;

        [JsonProperty(PropertyName = "errorMessage", Required = Required.Default)]
        public string ErrorMessage { get; set; } = "Not Found";

        #endregion

        #region Constructors

        public Response()
        {

        }

        #endregion

    }
}
