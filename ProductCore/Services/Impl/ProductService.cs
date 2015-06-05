using ProductCore.Dao;
using ProductCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Services.Impl
{
    public class ProductService : IProductService
    {
        public IProductDao ProductDao { get; set; }

        public Product AddProduct(Product product)
        {
            ProductDao.AddProduct(product);
            return GetProductByName(product.Name);
        }

        public void UpdateProduct(Product product)
        {
            ProductDao.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            product = ProductDao.GetProductByName(product.Name);

            if (product != null)
            {
                ProductDao.DeleteProduct(product);
            }
        }

        public IList<Product> GetAllProduct()
        {
            return ProductDao.GetAllProduct();
        }

        public Product GetProductByName(string name)
        {
            return ProductDao.GetProductByName(name);
        }

        public Product GetProductById(int id)
        {
            return ProductDao.GetProductById(id);
        }
    }
}
