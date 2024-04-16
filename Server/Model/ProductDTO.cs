using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace PresentationServer
{
    internal class ProductDTO : IProductDTO 
    {
        public ProductDTO()
        {

        }
        public ProductDTO(int id, string name, float price, int quantity, string platform, string genre)
        {
            this.id = id;
            this.quantity = quantity;
            this.name = name;
            this.price = price;
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
    public abstract class IProductDTO
    {
        public static IProductDTO CreateProduct(int id, string name, float price, int quantity, string platform, string genre)
        {
            return new ProductDTO(id, name, price, quantity, platform, genre);
        }
        public new int id { get; set; }
        public new int quantity { get; set; }
        public new string name { get; set; }
        public new float price { get; set; }
        public new string platform { get; set; }
        public new string genre { get; set; }
    }
}
