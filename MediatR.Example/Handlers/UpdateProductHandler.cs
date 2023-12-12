using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;
using MediatR.Example.Commands;

namespace MediatR.Example.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductAppSerives _ProductAppSerives;
        private readonly IUnitofWORk _UnitofWORk;

        public UpdateProductHandler(IProductAppSerives ProductAppSerives, IUnitofWORk unitofWORk)
        {
            _ProductAppSerives = ProductAppSerives;
            _UnitofWORk = unitofWORk;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var ProductDetails = await _ProductAppSerives.GetById(request.id);
            if (ProductDetails == null)
                return default;
            ProductDetails.ProductName = request.ProductName;
            ProductDetails.ProductDescription = request.ProductDescription;
            await _ProductAppSerives.Update(ProductDetails);
            _UnitofWORk.Commit();

            return ProductDetails;
        }
    }
}
