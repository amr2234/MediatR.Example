using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces;
using MediatR.Example.Commands;
using MediatR.Example.Query;
using Microsoft.AspNetCore.Authorization;
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

    }
}
