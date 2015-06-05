using ProductCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Dao.Mapper
{
    class ProductRowMapper : IRowMapper<Product>
    {
        public Product MapRow(IDataReader dataReader, int rowNum)
        {
            Product target = new Product();

            target.ID = dataReader.GetInt32(dataReader.GetOrdinal("ProductID"));
            target.Name = dataReader.GetString(dataReader.GetOrdinal("ProductName"));
            target.Price = dataReader.GetInt32(dataReader.GetOrdinal("ProductPrice"));
            target.Description = dataReader.GetString(dataReader.GetOrdinal("ProductDescription"));

            return target;
        }
    }
}
