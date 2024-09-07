namespace StudentsAffairs.INNOTECH.APIs.Errors
{
    public class ApiExceptionResponse : ApiResponse
    {
        public string? Detiles { get; set; }

        public ApiExceptionResponse(int statusCode, string? message = null, string? detiles = null)
            : base(statusCode, message)
        {
            Detiles = detiles;
        }


    }
}
