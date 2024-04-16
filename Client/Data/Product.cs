using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientData
{
    internal class Product : IProduct
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

        public int id;
        public int quantity;
        public string name;
        public float price;
        public string platform;
        public string genre; 
    }
    public abstract class IProduct
    {
        public static IProduct CreateProduct(int id, string name, float price, int quantity, string platform, string genre)
        {
            return new Product(id, name, price, quantity, platform, genre);
        }
        public new int id { get; set; }
        public new int quantity { get; set; }
        public new string name { get; set; }
        public new float price { get; set; }
        public new string platform { get; set; }
        public new string genre { get; set; }
    }
}
