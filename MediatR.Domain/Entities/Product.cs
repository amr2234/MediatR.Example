

using MediatR.Domain.Commen;

namespace MediatR.Domain.Entities
{
    public class Product:BaseClass
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

    }
}
