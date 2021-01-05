using Newtonsoft.Json;

namespace Core.Exceptions
{
    public class ExceptionResponse
    {
        public ExceptionResponse(string message, int statusCode = 500)
        {
            StatusCode = statusCode;
            Message = message;
        }

        private int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }
    }
}