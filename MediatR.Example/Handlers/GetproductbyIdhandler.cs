using MediatR.Example.Query;

namespace MediatR.Example.Handlers
{
    public class GetproductbyIdhandler : IRequestHandler<GetProductbyIdQuery,Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetproductbyIdhandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
            
            
        }
        public async Task<Product> Handle(GetProductbyIdQuery request, CancellationToken cancellationToken)
        {
         return  await _fakeDataStore.GetProductbyid(request.id);
        }
    }
}
