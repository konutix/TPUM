using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Product
    {
        internal Product(int id, string name, float price, int quantity, string platform, string genre)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.platform = platform;
            this.genre = genre;
        }

        internal int id { get; set; }
        internal int quantity { get; set; }
        internal string name { get; set; }
        internal float price { get; set; }
        internal string platform { get; set; }
        internal string genre { get; set; }
    }
}
