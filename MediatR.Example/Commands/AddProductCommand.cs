using MediatR.Domain.Entities;

namespace MediatR.Example.Commands
{
    public record AddProductCommand(Product product) : IRequest<Product>;

}
