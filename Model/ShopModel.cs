using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Model
{
    public class ShopModel
    {
        private ILogicLayer Shop { get; set; }    

        public ShopModel(ILogicLayer logicLayer)
        {
            Shop = logicLayer;

        }

        //public string shopName { get; set; }
        //public string homeTown { get; set; }
        //public string street { get; set; }
        //public int formed { get; set; }
        //public bool active { get; set; }
        //public Product[] products { get; set; }

        //public class Product
        //{
        //    public string name { get; set; }
        //    public float price { get; set; }
        //    public int quantity { get; set; }
        //    public string platform { get; set; }
        //    public string[] genre { get; set; }
        //}


        public List<ProductModel> GetGames()
        {
            List<ProductModel> games = new List<ProductModel>();
            foreach (int iter in Shop.GetProductIds())
            {
                Shop.GetProductById(iter, out string name, out float price, out int quantity, out string platform, out string genre);
                games.Add(new ProductModel(name, price, quantity, platform, genre));
            }
            return games;
        }

        
    }
}
