using Microsoft.AspNetCore.Mvc;
using WebDB_Test;


namespace Web_API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;
        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return productService.GetAll();
        }

       
        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return productService.GetById(id);
        }

        
        [HttpPost]
        public void Post(Product product)
        {
            productService.Add(product);
        }

       
        [HttpPut("{id}")]
        public void Put(Product product, Guid id)
        {
            productService.Update(product, id);
        }

       
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            productService.Delete(id);
        }
    }
}
