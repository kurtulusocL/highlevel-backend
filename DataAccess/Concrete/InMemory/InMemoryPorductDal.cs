using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryPorductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryPorductDal()
        {
            _products = new List<Product>
            {
                new Product{
                    ProductId=1,
                    CategoryId=1,
                    ProductName="Bardak",
                    UnitPrice=15,
                    UnitsInStock=15
                },
                new Product{
                    ProductId=2,
                    CategoryId=1,
                    ProductName="Sandalya",
                    UnitPrice=25,
                    UnitsInStock=5
                },
                new Product{
                    ProductId=3,
                    CategoryId=3,
                    ProductName="Masa",
                    UnitPrice=115,
                    UnitsInStock=50
                },
                new Product{
                    ProductId=4,
                    CategoryId=2,
                    ProductName="Hopörler",
                    UnitPrice=125,
                    UnitsInStock=12
                },
                new Product{
                    ProductId=5,
                    CategoryId=4,
                    ProductName="Mouse",
                    UnitPrice=105,
                    UnitsInStock=151
                }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product deleteProduct = _products.SingleOrDefault(i => i.ProductId == product.ProductId);
            _products.Remove(deleteProduct);
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
            return _products.Where(i => i.CategoryId == categoryId).ToList();
        }

        public Product GetById(int? id)
        {
            return (Product)_products.Where(i => i.ProductId == id);
        }

        public List<ProductDetailDto> GetProductDetials()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product updateProduct = _products.SingleOrDefault(i => i.ProductId == product.ProductId);
            updateProduct.ProductName = product.ProductName;
            updateProduct.CategoryId = product.CategoryId;
            product.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;
        }
    }
}
