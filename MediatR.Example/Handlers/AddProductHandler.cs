using MediatR.Example.Commands;
using MediatR;
using MediatR.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MediatR.Infrastructure.Data;
using System;
using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;


namespace MediatR.Example.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand,Product>
    {
        private readonly IProductAppSerives _Repo;
        private readonly IUnitofWORk _UnitofWORk;

        public AddProductHandler(IProductAppSerives Repo, IUnitofWORk UnitofWORk)
        {
            _Repo = Repo;
            _UnitofWORk=UnitofWORk;
                
           
            
        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
           

            await _Repo.Add(request.product);
            await _UnitofWORk.CommitAsync();
            return request.product ;

        }


      
    }
}
