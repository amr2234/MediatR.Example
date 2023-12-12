using MediatR.Example.Commands;
using MediatR;
using MediatR.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MediatR.Infrastructure.Data;
using System;
using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;
using MediatR.Example.Services;


namespace MediatR.Example.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductAppSerives _ProductAppSerives;
        private readonly IUnitofWORk _UnitOfWork;

        public AddProductHandler(IProductAppSerives ProductAppSerives, IUnitofWORk UnitofWORk)
        {
            _ProductAppSerives = ProductAppSerives;
            _UnitOfWork = UnitofWORk;

        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {

            await _ProductAppSerives.Add(request.product);
            await _UnitOfWork.CommitAsync();

            return request.product;

        }



    }
}
