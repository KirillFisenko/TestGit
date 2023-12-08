using Microsoft.AspNetCore.Mvc;
using Web_API_Test.Models;
using Web_API_Test.Services;

namespace Web_API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        [HttpGet]
        public List<Product> Get()
        {
            return ProductService.GetAll();
        }

       
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return ProductService.GetById(id);
        }

        
        [HttpPost]
        public void Post(Product product)
        {
            ProductService.Add(product);
        }

       
        [HttpPut("{id}")]
        public void Put(Product product, int id)
        {
            ProductService.Update(product, id);
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductService.Delete(id);
        }
    }
}
