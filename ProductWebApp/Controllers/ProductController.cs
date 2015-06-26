using ProductCore.Models;
using ProductCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace ProductWebApp.Controllers
{
    public class ProductController : ApiController
    {
        public IProductService ProductService { get; set; }

        [HttpPost]
        public Product AddProduct(Product product)
        {
            CheckProductIsNotNullThrowException(product);

            //try
            //{
                return ProductService.AddProduct(product);
            //}
            //catch (Exception)
            //{
            //    throw new HttpResponseException(HttpStatusCode.InternalServerError);
            //}
        }

        [HttpPut]
        public Product UpdateProduct(Product product)
        {
            CheckProductIsNullThrowException(product);

            try
            {
                ProductService.UpdateProduct(product);
                return ProductService.GetProductByName(product.Name);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteProduct(Product product)
        {
            try
            {
                ProductService.DeleteProduct(product);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Product> GetAllProduct()
        {
            return ProductService.GetAllProduct();
        }

        [HttpGet]
        public Product GetProductById(int id)
        {
            var product = ProductService.GetProductById(id);

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;
        }

        [HttpGet]
        [ActionName("Name")]
        public Product GetProductByName(string input)
        {
            var product = ProductService.GetProductByName(input);

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="product">
        ///     課程資料.
        /// </param>
        private void CheckProductIsNullThrowException(Product product)
        {
            Product dbProduct = ProductService.GetProductById(product.ID);

            if (dbProduct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="product">
        ///     課程資料.
        /// </param>
        private void CheckProductIsNotNullThrowException(Product product)
        {
            Product dbProduct = ProductService.GetProductById(product.ID);

            if (dbProduct != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
         }

    }
}