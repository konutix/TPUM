using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientData
{
    internal class Product
    {
        public Product()
        {

        }

        public Product(int id, string name, float price, int quantity, string platform, string genre)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.platform = platform;
            this.genre = genre;
        }

        public int id { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string platform { get; set; }
        public string genre { get; set; }
    }
}
