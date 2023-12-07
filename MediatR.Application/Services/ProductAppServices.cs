
using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;

namespace MediatR.Example.Services
{
    public class ProductAppServices : IProductAppSerives
    {
        IGenericRepository<Product> _rep;
   

        public ProductAppServices(IGenericRepository<Product> rep, IUnitofWORk unitofWORk)
        {
            _rep = rep;
          
        }

        public async Task<bool> Add(Product entity)
        {
            return await _rep.Add(entity);
            
        }

        public async Task<IEnumerable<Product>> All()
        {
            return await _rep.All();
            
        }

        public  async Task<bool> Delete(int id)
        {
            return await _rep.Delete(id);
           
        }

        public async Task<Product> GetById(int id)
        {
            return await _rep.GetById(id);
        }
    }
}
