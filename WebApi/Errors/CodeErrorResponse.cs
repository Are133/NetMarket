namespace WebApi.Errors
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessagesStatusCode(statusCode);
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        private string GetDefaultMessagesStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request, Review Information Before to Send",
                401 => "You dont have autorization for this resource",
                404 => "This resources not is available",
                500 => "Internal server error",
                _ => null
            };
        }
    }
}
