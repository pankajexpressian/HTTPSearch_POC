using HTTPSearch_POC.Models;

namespace HTTPSearch_POC.Services.Services
{
    public class ProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Description = "A high performance laptop" },
                new Product { Id = 2, Name = "Smartphone", Description = "An Android smartphone" },
                new Product { Id = 3, Name = "Headphones", Description = "Noise cancelling headphones" }
            };
        }

        public IEnumerable<Product> GetAll() => _products;

        public IEnumerable<Product> Search(string query)
        {
            return _products.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                        p.Description.Contains(query, StringComparison.OrdinalIgnoreCase));
        }
    }
}

