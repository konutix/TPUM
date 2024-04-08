using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Data
{
    internal class ShopData
    {
        internal ShopData()
        {
            shopName = "empty";
            homeTown = "empty";
            street = "empty";
            formed = 0;
            active = false;
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

        internal string shopName { get; set; }
        internal string homeTown { get; set; }
        internal string street { get; set; }
        internal int formed { get; set; }
        internal bool active { get; set; }
        internal List<Product> products { get; set; }
    }
}
