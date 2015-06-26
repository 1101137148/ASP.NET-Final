using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using ProductCore.Services;
using ProductCore.Models;

namespace ProductCoreTests.Services.Impl
{
    [TestClass]
    public class ProductServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/ProductCoreDatabase.xml",
                    "~/Config/ProductCorePointcut.xml",
                    "~/Config/ProductCoreTests.xml" 
                };
            }
        }

        #endregion

        public IProductService ProductService { get; set; }

        [TestMethod]
        public void TestProductService_AddProduct()
        {
            Product product = new Product();
            product.ID = 300;
            product.Name = "單元測試";
            product.Price = 400;
            product.Description = "請做出單元測試";
            ProductService.AddProduct(product);

            Product dbProduct = ProductService.GetProductByName(product.Name);
            Assert.IsNotNull(dbProduct);
            Assert.AreEqual(product.Name, dbProduct.Name);

            Console.WriteLine("產品編號為 = " + dbProduct.ID);
            Console.WriteLine("產品名稱為 = " + dbProduct.Name);
            Console.WriteLine("產品價格為 = " + dbProduct.Price);
            Console.WriteLine("產品描述為 = " + dbProduct.Description);

            ProductService.DeleteProduct(dbProduct);
            dbProduct = ProductService.GetProductByName(product.Name);
            Assert.IsNull(dbProduct);
        }

    }
}
