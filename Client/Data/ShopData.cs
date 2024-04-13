using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ClientData
{
    internal class ShopData : IObservable<Product>
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
            observers = new List<IObserver<Product>>();
        }

        internal void AddProduct(string name, float price, int quantity, string platform, string genre)
        {
            int newUniqueId = 0;

            bool found = false;
            while (!found)
            {
                bool exists = false;
                foreach (Product p in products)
                {
                    if (newUniqueId == p.id)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
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

        public IDisposable Subscribe(IObserver<Product> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        public string shopName { get; set; }
        public string homeTown { get; set; }
        public string street { get; set; }
        public int formed { get; set; }
        public bool active { get; set; }
        public string lastTransaction { get; set; }
        public List<Product> products { get; set; }
        public List<IObserver<Product>> observers { get; set; }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Product>> _observers;
            private IObserver<Product> _observer;

            public Unsubscriber(List<IObserver<Product>> observers, IObserver<Product> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
