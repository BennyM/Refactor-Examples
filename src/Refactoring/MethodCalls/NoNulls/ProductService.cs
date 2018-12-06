using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.MethodCalls.NoNulls
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();

        public void CreateProduct(string name)
        {
            if (GetProductByName(name).HasValue)
            {
                throw new ApplicationException($"Product with name {name} already exists");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("No name was supplied");
            }
            var product = new Product();
            product.Id = products.Count + 1;
            product.Name = name;
            products.Add(product);
        }

        public Maybe<Product> GetProductById(int id)
        {
            var product = products.SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                return Maybe<Product>.None;
            }
            return Maybe<Product>.Some(product);
        }
        public Maybe<Product> GetProductByName(string name)
        {
            var product = products.SingleOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                return Maybe<Product>.None;
            }
            return Maybe<Product>.Some(product);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}