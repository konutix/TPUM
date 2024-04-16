using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class LogicLayer : ILogicLayer
    {
        private IDataLayer Data { get; }
        private static readonly object padlock = new object();
        private bool Locked = false;
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

        public void GetShopData(out string shopName, out string homeTown, out string street, out int formed, out bool active, out string transaction)
        {
            Data.GetShopData(out shopName, out homeTown, out street, out formed, out active, out transaction);
        }

        public void SetShopData(string shopName, string homeTown, string street, int formed, bool active)
        {
            Data.SetShopData(shopName, homeTown, street, formed, active);
        }

        private class IdQuant
        {
            public int id;
            public int quant;

            public IdQuant(int i, int q) { id = i; quant = q; }
        }
        public bool checkTransaction(List<int> ids)
        {
            List<int> productIds = GetProductIds();
            List<IdQuant> idQuants = new List<IdQuant>();

            foreach(int id in productIds)
            {
                string name;
                float price;
                int quantity;
                string platform;
                string genre;

                GetProductById(id, out name, out price, out quantity, out platform, out genre);

                idQuants.Add(new IdQuant(id, quantity));
            }

            bool valid = true;

            foreach (int id in ids)
            {
                foreach (IdQuant prod in idQuants)
                {
                    if(prod.id == id)
                    {
                        if(prod.quant > 0)
                        {
                            prod.quant -= 1;
                        }
                        else
                        {
                            valid = false;
                        }
                    }
                }
            }

            return valid;
        }
        public bool TryLock()
        {
            lock (padlock)
            {
                if (Locked)
                {
                    return true;
                }
                else
                {
                    Locked = true;
                    return false;
                }
            }
        }

        public void Unlock()
        {
            Locked = false;
        }
    }
}
