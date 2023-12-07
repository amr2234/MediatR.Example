using MediatR.Domain.Entities;

namespace MediatR.Example.Query
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;

}
