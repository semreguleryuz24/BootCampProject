using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>{
                new Product{CategoryId=1, ProductName="Bardak",ProductId=1,UnitPrice=15,UnitsInStock=15},
                new Product{CategoryId=1, ProductName="Kamera",ProductId=2,UnitPrice=150,UnitsInStock=3},
                new Product{CategoryId=2, ProductName="Telefon",ProductId=3,UnitPrice=1500,UnitsInStock=5},
                new Product{CategoryId=2, ProductName="Klavye",ProductId=4,UnitPrice=30,UnitsInStock=65},
                new Product{CategoryId=2, ProductName="fare",ProductId=5,UnitPrice=85,UnitsInStock=1},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productTodelete = null;

            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productTodelete = p;
                }
            }


            productTodelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productTodelete);



        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
