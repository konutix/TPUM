using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ClientData
{
    internal class ShopData
    {
        public ShopData()
        {
            shopName = "empty";
            homeTown = "empty";
            street = "empty";
            formed = 0;
            active = false;
            lastTransaction = "";
            products = new List<Product>();
        }

        internal void AddProduct(string name, float price, int quantity, string platform, string genre)
        {
            int newUniqueId = 0;

            bool found = false;
            while(!found)
            {
                bool exists = false;
                foreach(Product p in products)
                {
                    if (newUniqueId == p.id)
                    {
                        exists = true;
                        break;
                    }
                }

                if(!exists)
                {
                    found = true;
                }
                else
                {
                    newUniqueId += 1;
                }
            }

            products.Add(new Product(newUniqueId, name, price, quantity, platform, genre));
        }

        public string shopName { get; set; }
        public string homeTown { get; set; }
        public string street { get; set; }
        public int formed { get; set; }
        public bool active { get; set; }
        public string lastTransaction { get; set; }
        public List<Product> products { get; set; }
    }
}
