using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces;
using MediatR.Example.Commands;
using MediatR.Example.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Example.Controllers
{
    [Authorize]
    public class ProductsController : BaseApiController
    {
        private readonly ISender _sender;


        public ProductsController(ISender sender)
        {
            _sender = sender;

        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Addproduct([FromBody]Product product)
        {

           var productToReturn = await _sender.Send(new AddProductCommand(product));
            return Ok(productToReturn);
        }

        [HttpGet("{id:int}", Name = "GetProductbyid")]
        public async Task<ActionResult> GetProductbyId(int id)
        {
           var product =  await _sender.Send(new GetProductbyIdQuery(id));
           return Ok(product);
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        public async Task<ActionResult> Updateproduct([FromBody] Product product)
        {

            var UpdatedProduct = await _sender.Send(new UpdateProductCommand(product.id,product.ProductName,product.ProductDescription));
            return Ok(UpdatedProduct);
        }
        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<int> Deleteproduct(int id)
        {
            return await _sender.Send(new DeleteProductCommand { Id = id });
        }

    }
}
