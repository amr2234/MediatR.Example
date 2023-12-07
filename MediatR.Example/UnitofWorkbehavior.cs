using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR.Domain.Interfaces.Persistence;

namespace MediatR.Domain
{
    public sealed class UnitofWorkbehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUnitofWORk _unitofWork;

        public UnitofWorkbehavior(IUnitofWORk unitofWoRk)
        {
            _unitofWork=unitofWoRk;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!typeof(TRequest).Name.EndsWith("Command"))
            {
                return await next();
            }

            var response = await next();
            await _unitofWork.CommitAsync();

            return response;
        }
    }
}
