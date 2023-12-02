namespace MediatR.Example.Query
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;

}
