namespace MediatR.Example
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product { Id = 1, Name = "Test1" },
                new Product { Id = 2, Name = "Test2" },
                new Product { Id = 3, Name = "Test3" }

            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
            
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
          return  await Task.FromResult(_products);

        }

        public async Task<Product> GetProductbyid(int id)=>await Task.FromResult(_products.Single(a => a.Id == id));
            
       
    }
}
