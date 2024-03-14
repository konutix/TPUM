using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Data.AbstractShopData;

namespace Data
{
    internal class Loading : IShopData
    {
        ShopData IShopData.loadShopData()
        {
            string fileName = "Data.json";
            string jsonString = File.ReadAllText(fileName);
            ShopData shopData =  JsonSerializer.Deserialize<ShopData>(jsonString);
            return shopData;
        }

        //public IShopData? ShopData { get; set; }
    }
}
