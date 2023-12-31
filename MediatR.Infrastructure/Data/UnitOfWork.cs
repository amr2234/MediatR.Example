﻿
using MediatR.Domain.Interfaces.Persistence;
using MediatR.Application.Interfaces;

namespace MediatR.Infrastructure.Data
{
    public class UnitOfWork : IUnitofWORk
    {
        private readonly DBContext_App _dbContext;


        public UnitOfWork(DBContext_App dbContext)
        {
            _dbContext = dbContext;
        }


        public IProductRepository ProductRepository()
        {
            return new ProductRepository(_dbContext);
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
