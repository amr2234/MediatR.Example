using MediatR.Application.Interfaces;
using MediatR.Domain.Entities;


namespace MediatR.Infrastructure.Data
{
    public class ProductRepository : GenaricRepository<Product> , IProductRepository
    {
        public ProductRepository(DBContext_App context) : base(context)
        {

        }
    }
}

