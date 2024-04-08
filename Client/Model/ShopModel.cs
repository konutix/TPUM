using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logic;
using System.Collections.ObjectModel;
using Model;

namespace Model
{
    public class ShopModel : IShopModel
    {
        private ILogicLayer Shop { get; set; }

        public ShopModel(ILogicLayer logicLayer)
        {
            Shop = logicLayer;
            BuyList = new List<IProductModel> { };   
        }

        public List<IProductModel> BuyList { get; set; }

        //public string shopName { get; set; }
        //public string homeTown { get; set; }
        //public string street { get; set; }
        //public int formed { get; set; }
        //public bool active { get; set; }
        //public Product[] products { get; set; }

        public void RemoveProducts()
        {
            foreach (IProductModel product in BuyList)
            {
                Shop.RemoveProduct(product.ID, 1);
            }
        }

        public List<IProductModel> GetGames()
        {
            List<IProductModel> games = new List<IProductModel>();
            foreach (int iter in Shop.GetProductIds())
            {
                Shop.GetProductById(iter, out string name, out float price, out int quantity, out string platform, out string genre);
                games.Add(new ProductModel(iter, name, price, quantity, platform, genre));
            }
            return games;
        }


    }
}
