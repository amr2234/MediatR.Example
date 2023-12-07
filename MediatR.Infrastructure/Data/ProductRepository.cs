using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Infrastructure.Data
{
    public class ProductRepository : GenaricRepository<Product> , IProductRepository
    {
        public ProductRepository(DBContext_App context) : base(context)
        {

        }
    }
}

