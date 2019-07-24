using System.Collections.Generic;
using AspectOrientedProgramming.Aspect;

namespace AspectOrientedProgramming
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class ProductService : IProductService
    {
        // In memory olarak bir kaç product ekliyorum.
        private static Dictionary<int, Product> _InMemDb = new Dictionary<int, Product>();

        public ProductService()
        {
            _InMemDb.Add(1, new Product() { Id = 1, Name = "MacBook Air", Price = 3000 });
            _InMemDb.Add(2, new Product() { Id = 2, Name = "Sony Xperia Z Ultra", Price = 1400 });
        }

        [Cache(DurationInMinute = 10)]
        [Log]
        public Product GetProduct(int productId)
        {
            return _InMemDb[productId];
        }
    }
}
