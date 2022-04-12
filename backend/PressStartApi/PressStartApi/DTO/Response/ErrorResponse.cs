namespace PressStartApi.DTO.Response
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<DetailError>();
        }

        public ErrorResponse(int errorRef, string message, int statusCode = 500)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<DetailError>();
            AddError(errorRef, message, statusCode);
        }

        public string TraceId { get; private set; }
        public List<DetailError> Errors { get; private set; }

        public class DetailError
        {
            public DetailError(int errorRef, string message, int statusCode)
            {
                ErrorRef = errorRef;
                Message = message;
                StatusCode = statusCode;
            }

            public int ErrorRef { get; private set; }
            public string Message { get; private set; }
            public int StatusCode { get; private set; }

        }

        public void AddError(int errorRef, string message, int statusCode)
        {
            Errors.Add(new DetailError(errorRef, message, statusCode));
        }
    }
}
