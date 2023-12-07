using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces.Features;
using MediatR.Example.Query;
using MediatR.Infrastructure.Data;

namespace MediatR.Example.Handlers
{
    public class GetproductbyIdhandler : IRequestHandler<GetProductbyIdQuery,Product>
    {
        private readonly IProductAppSerives _Repo;

        public GetproductbyIdhandler(IProductAppSerives Repo)
        {
            _Repo = Repo;


        }
        public async Task<Product> Handle(GetProductbyIdQuery request, CancellationToken cancellationToken)
        {
         return  await _Repo.GetById(request.id);
        }
    }
}
