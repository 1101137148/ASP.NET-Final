using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using ProductCore.Dao;
using ProductCore.Models;

namespace ProductCoreTests.Dao
{
    [TestClass]
    public class ProductDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    "~/Config/ProductCoreDatabase.xml",
                    "~/Config/ProductCorePointcut.xml",
                    "~/Config/ProductCoreTests.xml" 
                };
            }
        }

        #endregion

        public IProductDao ProductDao { get; set; }

        [TestMethod]
        public void TestProductDao_AddProduct()
        {
            Product product = new Product();
            product.ID = 100;
            product.Name = "單元測試";
            product.Price = 200;
            product.Description = "請做出單元測試";
            ProductDao.AddProduct(product);

            Product dbProduct = ProductDao.GetProductByName(product.Name);
            Assert.IsNotNull(dbProduct);
            Assert.AreEqual(product.Name, dbProduct.Name);

            Console.WriteLine("產品編號為 = " + dbProduct.ID);
            Console.WriteLine("產品名稱為 = " + dbProduct.Name);
            Console.WriteLine("產品價格為 = " + dbProduct.Price);
            Console.WriteLine("產品描述為 = " + dbProduct.Description);

            ProductDao.DeleteProduct(dbProduct);
            dbProduct = ProductDao.GetProductByName(product.Name);
            Assert.IsNull(dbProduct);
        }
    }
}
