namespace MediatR.Example.Query
{
    public record GetProductbyIdQuery(int id) : IRequest<Product>;

    
}
