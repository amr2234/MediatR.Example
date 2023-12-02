using MediatR.Example.Commands;
using MediatR.Example.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)=>_sender = sender;

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

    }
}
