using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces;
using MediatR.Domain.Interfaces.Persistence;


namespace MediatR.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
