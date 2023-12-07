using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;
using MediatR.Domain.Entities;

namespace MediatR.Infrastructure.Data
{
    public class UnitOfWork : IUnitofWORk
    {
        private readonly DBContext_App _dbContext;
        private IProductRepository _ProductRepo;


        public UnitOfWork(DBContext_App dbContext)
        {
            _dbContext = dbContext;
        }


        public IProductRepository ProductRepository()
        {
            return  new ProductRepository(_dbContext); 
        }

        public IProductRepository Product => throw new NotImplementedException();

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();

   

        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
