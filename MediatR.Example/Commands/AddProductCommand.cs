namespace MediatR.Example.Commands
{
    public record AddProductCommand(Product product) : IRequest<Product>;

}
