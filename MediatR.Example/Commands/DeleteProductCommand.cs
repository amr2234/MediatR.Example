using MediatR.Domain.Entities;

namespace MediatR.Example.Commands
{
    public class DeleteProductCommand() : IRequest<int>
    {
        public int Id { get; set; }
    }
   
}
