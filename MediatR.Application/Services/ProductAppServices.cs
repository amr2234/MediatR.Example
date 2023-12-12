
using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces;
using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;

namespace MediatR.Example.Services
{
    public class ProductAppServices : IProductAppSerives
    {
        IGenericRepository<Product> _IGenaricRepo;
   

        public ProductAppServices(IGenericRepository<Product> IGenaricRepo)
        {
            _IGenaricRepo = IGenaricRepo;
          
        }

        public async Task<bool> Add(Product entity)
        {
            return await _IGenaricRepo.Add(entity);
            
        }

        public async Task<IEnumerable<Product>> All()
        {
            return await _IGenaricRepo.All();
            
        }

        public  async Task<bool> Delete(int id)
        {
            return await _IGenaricRepo.Delete(id);
           
        }

        public async Task<Product> GetById(int id)
        {
            return await _IGenaricRepo.GetById(id);
        }

        public async Task<bool> Update(Product entity)
        {
            return await _IGenaricRepo.Update(entity);
        }
    }
}
