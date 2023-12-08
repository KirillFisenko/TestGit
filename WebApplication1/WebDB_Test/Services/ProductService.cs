using Microsoft.EntityFrameworkCore;

namespace WebDB_Test
{
    public class ProductService
    {        
        private readonly DatabaseContext dbContext;
        public ProductService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return dbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }

        public void Update(Product product, Guid id)
        {
            var currentProduct = GetById(id);
            currentProduct.Price = product.Price;
            currentProduct.Name = product.Name;
            dbContext.Products.Update(currentProduct);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = GetById(id);
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }
    }
}
