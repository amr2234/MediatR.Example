using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces.Features;

namespace MediatR.Domain.Interfaces.Persistence
{
    public interface IUnitofWORk
    {
        IProductRepository Product { get; } // we have only get because we don't want to set the repository. setting the repository will be done in the UnitOfWork class
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
        // this method will save all the changes made to the database
    }
}
