using System.Reflection.Metadata;
using MediatR.Example.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Example.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand,Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public AddProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
           
            
        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.product);
            return request.product ;

        }


      
    }
}
