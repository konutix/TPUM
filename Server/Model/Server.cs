using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Timers;
using System.Data;

namespace PresentationServer
{
    internal class ServerInit : WebSocketBehavior
    {
        private Server _serverinst;
        public ServerInit(Server serverinst)
        {
            _serverinst = serverinst;
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Recieved: " + e.Data + "\n");
            List<int> ids = new List<int>();
            ids = JsonConvert.DeserializeObject<List<int>>(e.Data);
            
            if(_serverinst.logicLayer.checkTransaction(ids))
            {
                foreach (int id in ids)
                {
                    _serverinst.logicLayer.RemoveProduct(id, 1);
                }
                _serverinst.Send(_serverinst.logicLayer, "success");
            }
            else
            {
                _serverinst.Send(_serverinst.logicLayer, "fail");
            }

            Console.WriteLine("Sent: " + _serverinst.message + "\n");
            Send(_serverinst.message);
        }
    }
    internal class ServerBroadcast : WebSocketBehavior
    {
        private Server _serverinst;
        public ServerBroadcast(Server serverinst)
        {
            _serverinst = serverinst;
            Update();
        }

        internal void Update()
        {
            System.Timers.Timer UpdateTimer = new System.Timers.Timer(10000);
            UpdateTimer.Elapsed += Broadcast;
            UpdateTimer.AutoReset = true;   
            UpdateTimer.Enabled = true;
        }
        internal void Broadcast(Object source, ElapsedEventArgs e)
        {
            
            _serverinst.Send(_serverinst.logicLayer, "update");
            Console.WriteLine("Sent: " + _serverinst.message + "\n");
            Sessions.Broadcast(_serverinst.message);
        }
        
    }

    internal class Server
    {
        //internal static ILogicLayer logicLayer {get;set;}
        public ILogicLayer logicLayer {get;set;}
        private ShopDTO shopData;
        internal string message {get; set;}
        Server(ILogicLayer logicLayer)
        {
            this.logicLayer = logicLayer;
            products = new List<ProductDTO>();
            sendShop = new ShopDTO();

            UpdateData(logicLayer, "update");
            message = JsonConvert.SerializeObject(sendShop);

            WebSocketServer webSocketServer = new WebSocketServer("ws://127.0.0.1:5000");
            webSocketServer.AddWebSocketService<ServerInit>("/ServerInit", () => new ServerInit(this));
            webSocketServer.AddWebSocketService<ServerBroadcast>("/ServerBroadcast", () => new ServerBroadcast(this));
            //ServerBroadcast broadcast = new ServerBroadcast(this);
            //Update(broadcast);
            webSocketServer.Start();
            Console.WriteLine("Server started on ws://127.0.0.1:5000");
            Console.ReadKey();
            webSocketServer.Stop();
        }


        static async Task Main()
        {
            ILogicLayer logicLayer = ILogicLayer.CreateLogicLayer();
            Server server = new Server(logicLayer);


        }

        private void WebSocket_OnMessage(object? sender, MessageEventArgs e)
        {
            shopData = JsonConvert.DeserializeObject<ShopDTO>(e.Data);
        }

        internal async void Send(ILogicLayer logicLayer, string transactionResult)
        {
            UpdateData(logicLayer, transactionResult);
            message = JsonConvert.SerializeObject(sendShop);
        }

        internal void UpdateData(ILogicLayer logicLayer, string transactionResult)
        {
            logicLayer.GetShopData(out string shopName, out string homeTown, out string street, out int formed, out bool active, out string transaction);
            sendShop.shopName = shopName;
            sendShop.homeTown = homeTown;
            sendShop.street = street;
            sendShop.formed = formed;
            sendShop.active = active;
            sendShop.lastTransaction = transactionResult;
            productIDS = logicLayer.GetProductIds();
            sendShop.products = GetGames();
        }

        public List<ProductDTO> GetGames()
        {
            List<ProductDTO> games = new List<ProductDTO>();
            foreach (int iter in productIDS)
            {
                logicLayer.GetProductById(iter, out string name, out float price, out int quantity, out string platform, out string genre);
                games.Add(new ProductDTO(iter, name, price, quantity, platform, genre));
            }
            return games;
        }

        private List<ProductDTO> products { get; set; }
        private List<int> productIDS { get; set; }
        private ShopDTO sendShop { get; set; }
    }
}
