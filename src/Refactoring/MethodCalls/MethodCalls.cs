using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.MethodCalls
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();
        public Product CreateProduct(string name)
        {
            if (!products.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                var product = new Product();
                product.Id = products.Count + 1;
                product.Name = name;
                products.Add(product);
                return product;
            }
            return null;
        }

        public Product GetProductById(int id)
        {
            return products.SingleOrDefault(x => x.Id == id);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}