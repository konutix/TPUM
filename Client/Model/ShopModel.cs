using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClientLogic;
using System.Collections.ObjectModel;
using Model;

namespace Model
{
    public class ShopModel : IShopModel
    {
        public event EventHandler ItemsChanged;
        public event EventHandler TransactionFailed;
        public event EventHandler TransactionSucceeded;

        private ILogicLayer Shop { get; set; }

        public ShopModel(ILogicLayer logicLayer)
        {
            Shop = logicLayer;
            BuyList = new List<IProductModel> { };

            Shop.ItemsChanged += Shop_ItemsChanged;
            Shop.TransactionFailed += Shop_TransactionFailed;
            Shop.TransactionSucceeded += Shop_TransactionSucceeded;
        }

        private void Shop_TransactionSucceeded(object? sender, EventArgs e)
        {
            ItemsChanged?.Invoke(this, e);
        }

        private void Shop_TransactionFailed(object? sender, EventArgs e)
        {
            TransactionFailed?.Invoke(this, e);
        }

        private void Shop_ItemsChanged(object? sender, EventArgs e)
        {
            TransactionSucceeded?.Invoke(this, e);
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
            List<int> ids = new List<int>();

            foreach (IProductModel product in BuyList)
            {
                ids.Add(product.ID);
            }

            Shop.RemoveProducts(ids);
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
