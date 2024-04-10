﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class LogicLayer : ILogicLayer
    {
        public event EventHandler ItemsChanged;
        public event EventHandler TransactionFailed;
        public event EventHandler TransactionSucceeded;

        private IDataLayer Data { get; }

        public LogicLayer(IDataLayer data)
        {
            Data = data;
            Data.DrawData();
        }

        public List<int> GetProductIds()
        {
            return Data.GetProductIds();
        }

        public void GetProductById(int id, out string name, out float price, out int quantity, out string platform, out string genre)
        {
            Data.GetProductById(id, out name, out price, out quantity, out platform, out genre);
        }

        public void AddNewProduct(string name, float price, int quantity, string platform, string genre)
        {
            if (price >= 0.0f && quantity >= 0 && name != string.Empty && platform != string.Empty && genre != string.Empty)
            {
                Data.AddNewProduct(name, price, quantity, platform, genre);
            }
        }

        public void AddExistingProduct(int id, int quant)
        {
            if(quant >= 0)
            {
                Data.AddExistingProduct(id, quant);
            }
        }

        public bool RemoveProduct(int id, int quant)
        {
            if (quant >= 0)
            {
                return Data.RemoveProduct(id, quant);
            }

            return false;
        }

        public void ChangePrice(int id, float newPrice)
        {
            if(newPrice >= 0.0f)
            {
                Data.ChangePrice(id, newPrice);
            }
        }

        public void GetShopData(out string shopName, out string homeTown, out string street, out int formed, out bool active)
        {
            Data.GetShopData(out shopName, out homeTown, out street, out formed, out active);
        }

        public void SetShopData(string shopName, string homeTown, string street, int formed, bool active)
        {
            Data.SetShopData(shopName, homeTown, street, formed, active);
        }
    }
}
