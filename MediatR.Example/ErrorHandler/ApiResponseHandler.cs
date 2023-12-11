namespace MediatR.Example.ErrorHandling
{
    public class ApiResponseHandler
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public ApiResponseHandler(int Statuscode, string Message = null)
        {
            StatusCode = Statuscode;
            ErrorMessage = Message ?? GetDefaultMassage(Statuscode);

        }

        private string GetDefaultMassage(int statuscode) => statuscode switch
        {
            400 => " Bad Request ",
            401 => " You are not Authorized",
            404 => " Resource Not found",
            500 => " Internal Server Error",
            _ => null
        };
    }
}
