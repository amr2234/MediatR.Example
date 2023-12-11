namespace MediatR.Example.ErrorHandling
{
    public class ApiExceptionHandler : ApiResponseHandler
    {
        public string Detials { get; set; }
        public ApiExceptionHandler(int Statuscode, string Message = null, string details = null) : base(Statuscode, Message)
        {

            Detials = details;
        
        }
    }
}
