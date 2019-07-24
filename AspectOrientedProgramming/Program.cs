using System;

namespace AspectOrientedProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            // Servis örneğini oluşturuyoruz.
            var productService = TransparentProxy<ProductService, IProductService>.GenerateProxy();

            // Servis üzerinden GetProduct metotunu çağırıyoruz.
            var product = productService.GetProduct(1);

            Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", product.Id, product.Name, product.Price);
            Console.ReadLine();
        }
    }
}
