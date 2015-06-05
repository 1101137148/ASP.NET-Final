using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return "Product: Id = " + ID + ", Name = " + Name + ".";
        }
    }
}
