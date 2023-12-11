

using MediatR.Application.Interfaces;
namespace MediatR.Domain.Interfaces.Persistence
{
    public interface IUnitofWORk
    {
        IProductRepository Product { get; } 
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
       
    }
}
