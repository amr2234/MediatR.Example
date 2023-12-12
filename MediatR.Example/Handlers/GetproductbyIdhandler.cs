using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces.Features;
using MediatR.Example.Query;
using MediatR.Example.Services;
using MediatR.Infrastructure.Data;

namespace MediatR.Example.Handlers
{
    public class GetproductbyIdhandler : IRequestHandler<GetProductbyIdQuery, Product>
    {
        private readonly IProductAppSerives _ProductAppSerives;

        public GetproductbyIdhandler(IProductAppSerives ProductAppSerives)
        {
            _ProductAppSerives = ProductAppSerives;


        }
        public async Task<Product> Handle(GetProductbyIdQuery request, CancellationToken cancellationToken)
        {
            return await _ProductAppSerives.GetById(request.id);
        }
    }
}
