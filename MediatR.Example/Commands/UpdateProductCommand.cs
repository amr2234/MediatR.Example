using MediatR.Domain.Entities;

namespace MediatR.Example.Commands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public UpdateProductCommand(int id, string productName, string productDescription)
        {
            this.id = id;
            ProductName = productName;
            ProductDescription = productDescription;
        }

        public int id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }



    }

}
