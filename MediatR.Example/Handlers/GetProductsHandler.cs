using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces.Features;
using MediatR.Example.Query;
using MediatR.Infrastructure.Data;

namespace MediatR.Example.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductAppSerives _ProductAppSerives;

        public GetProductsHandler(IProductAppSerives ProductAppSerives)
        {
            _ProductAppSerives = ProductAppSerives;


        }
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _ProductAppSerives.All();
        }
    }
}
