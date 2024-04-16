using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebSocketSharp;

namespace ClientData
{
    internal class DataLayer : IDataLayer, IObservable<Product>, IObserver<Product>
    {
        public override event EventHandler ItemsChanged;

        private ShopData shopData;
        private bool initialDataDrawn = false;
        private MessageEventArgs eargs;
        public List<IObserver<Product>> observers { get; set; }

        WebSocket webSocket;
        WebSocket webSocket2;

        private IDisposable unsubscriber;

        public DataLayer()
        {
            observers = new List<IObserver<Product>>();
            shopData = new ShopData();
            Subscribe(this);
            DrawData();
        }

        public DataLayer(bool observe)
        {
            observers = new List<IObserver<Product>>();
            shopData = new ShopData();
            DrawData();
        }

        public override void DrawData()
        {
            if (!initialDataDrawn)
            {
                initialDataDrawn = true;

                ShopData sendShop = new ShopData();

                sendShop.shopName = "GameShop1";
                sendShop.homeTown = "Lodz";
                sendShop.street = "Politechniki";
                sendShop.formed = 1111;
                sendShop.active = true;
                sendShop.AddProduct("Wiedzmak", 70.0f, 15, "PC", "ARPG");
                sendShop.AddProduct("Wiedzmak 2", 150.0f, 10, "PC", "ARPG");
                sendShop.AddProduct("Szyberpunk 2033", 210.0f, 21, "PS5", "FPS-RPG");

                //WEBSOCK
                webSocket = new WebSocket("ws://127.0.0.1:5000/ServerInit");
                webSocket2 = new WebSocket("ws://127.0.0.1:5000/ServerBroadcast");

                webSocket.OnMessage += WebSocket_OnMessage;
                webSocket2.OnMessage += WebSocket_OnMessage;

                webSocket.Connect();
                webSocket2.Connect();
                string message = JsonConvert.SerializeObject(sendShop);
                //webSocket.Send(message);

            }
        }

        //WEBSOCK FUNC
        private void WebSocket_OnMessage(object? sender, MessageEventArgs e)
        {
            eargs = e;
            shopData = JsonConvert.DeserializeObject<ShopData>(e.Data);
            if (observers.Count() == 0)
            {
                ItemsChanged?.Invoke(this, e);
            }
            else
            {
                foreach (var observer in observers)
                    foreach (Product product in shopData.products)
                    {
                        observer.OnNext(product);
                    }
            }
        }

        public override void AddExistingProduct(int id, int quant)
        {
            foreach (Product p in shopData.products)
            {
                if (id == p.id)
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

        public override void RemoveProducts(List<int> ids)
        {
            ////FOR SELF SUFICIENCY ONLY
            //ShopData sendShop = new ShopData();
            //sendShop.shopName = "GameShop1";
            //sendShop.homeTown = "Lodz";
            //sendShop.street = "Politechniki";
            //sendShop.formed = 1111;
            //sendShop.active = true;
            //sendShop.lastTransaction = "success";
            //sendShop.AddProduct("Wiedzmak", 70.0f, 15, "PC", "ARPG");
            //sendShop.AddProduct("Wiedzmak 2", 150.0f, 10, "PC", "ARPG");
            //sendShop.AddProduct("Szyberpunk 2033", 210.0f, 21, "PS5", "FPS-RPG");
            //foreach (int id in ids)
            //{
            //    foreach (Product p in shopData.products)
            //    {
            //        if (id == p.id)
            //        {
            //            if (p.quantity >= 1)
            //            {
            //                p.quantity -= 1;
            //            }
            //            else
            //            {
            //                sendShop.lastTransaction = "fail";
            //            }
            //            break;
            //        }
            //    }
            //}

            string message = JsonConvert.SerializeObject(ids);
            //string message = JsonConvert.SerializeObject(shopData); //temporary
            webSocket.Send(message);
        }

        public override void SetShopData(string shopName, string homeTown, string street, int formed, bool active)
        {
            shopData.shopName = shopName;
            shopData.homeTown = homeTown;
            shopData.street = street;
            shopData.formed = formed;
            shopData.active = active;
        }

        public override void GetTransactionStatus(out string lastTransaction)
        {
            lastTransaction = shopData.lastTransaction;
        }

        void IObserver<Product>.OnCompleted()
        {
            this.Unsunscribe();
        }

        void IObserver<Product>.OnError(Exception error)
        {
        }

        void IObserver<Product>.OnNext(Product value)
        {
            //if (this.shopData.products.Where(p => p.id == value.id) != null)
            {
                ItemsChanged.Invoke(this, eargs);
            }
        }

        private void Unsunscribe()
        {
            unsubscriber.Dispose();
        }
        public IDisposable Subscribe(IObserver<Product> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }
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
