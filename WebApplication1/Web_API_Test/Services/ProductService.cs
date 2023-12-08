using Web_API_Test.Models;

namespace Web_API_Test.Services
{
    public class ProductService
    {
        public static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Product1", Price = 100},
            new Product { Id = 2, Name = "Product2", Price = 540}
        };

        public static List<Product> GetAll()
        {
            return products;
        }

        public static Product GetById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public static void Add(Product product)
        {
            products.Add(product);
        }

        public static void Update(Product product, int id)
        {
            var index = products.FindIndex(x => x.Id == id);
            products[index] = product;
        }

        public static void Delete(int id)
        {
            var index = products.FindIndex(x => x.Id == id);
            products.Remove(products[index]);
        }
    }
}
