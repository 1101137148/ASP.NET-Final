using ProductCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Services
{
    public interface IProductService
    {
        Product AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        IList<Product> GetAllProduct();

        Product GetProductByName(string name);

        Product GetProductById(int id);
    }
}
