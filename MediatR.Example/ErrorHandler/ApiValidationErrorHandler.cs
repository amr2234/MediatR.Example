using MediatR.Example.ErrorHandling;

namespace MediatR.Example.ErrorHandler
{
    public class ApiValidationErrorHandler : ApiResponseHandler
    {
        public ApiValidationErrorHandler() : base(400) { }
     
        public IEnumerable<string> Errors { get; set; }
    }
}
