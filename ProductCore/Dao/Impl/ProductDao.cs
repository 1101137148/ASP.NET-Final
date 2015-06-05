using ProductCore.Dao.Base;
using ProductCore.Dao.Mapper;
using ProductCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Dao.Impl
{
    public class ProductDao : GenericDao<Product>, IProductDao
    {
        override protected IRowMapper<Product> GetRowMapper()
        {
            return new ProductRowMapper();
        }

        public void AddProduct(Product product)
        {
            string command = @"INSERT INTO Product (ProductID, ProductName, ProductPrice, ProductDescription) VALUES (@Id, @Name, @Price, @Description);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.Int32).Value = product.ID;
            parameters.Add("Name", DbType.String).Value = product.Name;
            parameters.Add("Price", DbType.Int32).Value = product.Price;
            parameters.Add("Description", DbType.String).Value = product.Description;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateProduct(Product product)
        {
            string command = @"UPDATE Product SET ProductName = @Name, ProductPrice = @Price , ProductDescription = @Description WHERE ProductID = @Id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.Int32).Value = product.ID;
            parameters.Add("Name", DbType.String).Value = product.Name;
            parameters.Add("Price", DbType.Int32).Value = product.Price;
            parameters.Add("Description", DbType.String).Value = product.Description;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteProduct(Product product)
        {
            string command = @"DELETE FROM Product WHERE ProductID = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = product.ID;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Product> GetAllProduct()
        {
            string command = @"SELECT * FROM Product ORDER BY ProductID ASC";
            IList<Product> product = ExecuteQueryWithRowMapper(command);
            return product;
        }

        public Product GetProductByName(string name)
        {
            string command = @"SELECT * FROM Product WHERE ProductName = @Name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Name", DbType.String).Value = name;

            IList<Product> product = ExecuteQueryWithRowMapper(command, parameters);
            if (product.Count > 0)
            {
                return product[0];
            }

            return null;
        }

        public Product GetProductById(int id)
        {
            string command = @"SELECT * FROM Product WHERE ProductID = @id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.Int32).Value = id;

            IList<Product> product = ExecuteQueryWithRowMapper(command, parameters);
            if (product.Count > 0)
            {
                return product[0];
            }

            return null;
        }

    }
}
