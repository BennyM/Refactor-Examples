using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.MethodCalls.CommandQuery
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();

        public void CreateProduct(string name)
        {
            if (GetProductByName(name) != null)
            {
                throw new ApplicationException($"Product with name {name} already exists");
            }
            var product = new Product();
            product.Id = products.Count + 1;
            product.Name = name;
            products.Add(product);
        }

        public Product GetProductById(int id)
        {
            return products.SingleOrDefault(x => x.Id == id);
        }
        public Product GetProductByName(string name)
        {
            return products.SingleOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}