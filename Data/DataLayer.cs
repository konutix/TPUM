using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    internal class DataLayer : IDataLayer
    {
        private ShopData shopData;

        public DataLayer()
        {
            shopData = new ShopData();
            DrawData();
        }

        public override void DrawData()
        {
            shopData.shopName = "GameShop1";
            shopData.homeTown = "Lodz";
            shopData.street = "Politechniki";
            shopData.formed = 1111;
            shopData.active = true;
            shopData.AddProduct("Wiedzmak", 70.0f, 15, "PC", "ARPG");
            shopData.AddProduct("Wiedzmak 2", 150.0f, 10, "PC", "ARPG");
            shopData.AddProduct("Szyberpunk 2033", 210.0f, 21, "PS5", "FPS-RPG");
        }

        public override void AddExistingProduct(int id, int quant)
        {
            foreach(Product p in shopData.products)
            {
                if(id == p.id)
                {
                    p.quantity += quant;
                    break;
                }
            }
        }

        public override void AddNewProduct(string name, float price, int quantity, string platform, string genre)
        {
            shopData.AddProduct(name, price, quantity, platform, genre);
        }

        public override void ChangePrice(int id, float newPrice)
        {
            foreach (Product p in shopData.products)
            {
                if (id == p.id)
                {
                    p.price = newPrice;
                    break;
                }
            }
        }

        public override void GetProductById(int id, out string name, out float price, out int quantity, out string platform, out string genre)
        {
            name = "error";
            price = 0.0f;
            quantity = 0;
            platform = "error";
            genre = "error";

            foreach (Product p in shopData.products)
            {
                if (id == p.id)
                {
                    name = p.name;
                    price = p.price;
                    quantity = p.quantity;
                    platform = p.platform;
                    genre = p.genre;
                    break;
                }
            }
        }

        public override List<int> GetProductIds()
        {
            List<int> ids = new List<int>();

            foreach (Product p in shopData.products)
            {
                ids.Add(p.id);
            }

            return ids;
        }

        public override void GetShopData(out string shopName, out string homeTown, out string street, out int formed, out bool active)
        {
            shopName = shopData.shopName;
            homeTown = shopData.homeTown;
            street = shopData.street;
            formed = shopData.formed;
            active = shopData.active;
        }

        public override bool RemoveProduct(int id, int quant)
        {
            bool success = false;

            foreach (Product p in shopData.products)
            {
                if (id == p.id)
                {
                    if (p.quantity >= quant)
                    {
                        p.quantity -= quant;
                        success = true;
                    }
                    break;
                }
            }

            return success;
        }

        public override void SetShopData(string shopName, string homeTown, string street, int formed, bool active)
        {
            shopData.shopName = shopName;
            shopData.homeTown = homeTown;
            shopData.street = street;
            shopData.formed = formed;
            shopData.active = active;
        }
    }
}
