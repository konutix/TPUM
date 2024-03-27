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
        private IShop Shop { get; set; }    

        public ShopModel(IShop shop)
        {
            Shop = shop;

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
            foreach (ProductModel game in Shop.GetProducts())
            {
                games.Add(new ProductModel(game.name, game.price, game.quantity, game.platform, game.genres));
            }
            return games;
        }

        
    }
}
