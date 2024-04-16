using ClientData;
using Logic;
using PresentationServer;

namespace IntegrationTest
{
    [TestClass]
    public class TestServerClient
    {
        [TestMethod]
        public void TestMethod()
        {
            ILogicLayer logicLayer = ILogicLayer.CreateLogicLayer();
            Server server = new Server(logicLayer, false);
            Assert.IsNotNull(server);

            IDataLayer dataLayer = IDataLayer.CreateDataLayer(false);
            Assert.IsNotNull(dataLayer);

            //datatesty
            List<int> ids = new List<int>
            {
                0, 1, 2
            };
            dataLayer.RemoveProducts(ids);
            Thread.Sleep(3000);

            string name;
            float price;
            int quantity;
            string platform;
            string genre;

            dataLayer.GetProductById(0, out name, out price, out quantity, out platform, out genre);
            Assert.AreEqual(14, quantity);

            dataLayer.GetProductById(1, out name, out price, out quantity, out platform, out genre);
            Assert.AreEqual(9, quantity);

            dataLayer.GetProductById(2, out name, out price, out quantity, out platform, out genre);
            Assert.AreEqual(20, quantity);

            server.StopServer();
        }

        [TestMethod]
        public void CollisionTest()
        {
            ILogicLayer logicLayer = ILogicLayer.CreateLogicLayer();
            Server server = new Server(logicLayer, false);
            Assert.IsNotNull(server);

            IDataLayer dataLayer1 = IDataLayer.CreateDataLayer(false);
            Assert.IsNotNull(dataLayer1);

            IDataLayer dataLayer2 = IDataLayer.CreateDataLayer(false);
            Assert.IsNotNull(dataLayer2);

            //datatesty
            List<int> ids = new List<int>
            {
                0, 1, 2, 0, 1, 2, 0, 1, 2,
                0, 1, 2, 0, 1, 2, 0, 1, 2,
                0, 1, 2, 0, 1, 2, 0, 1, 2
            };
            dataLayer1.RemoveProducts(ids);
            dataLayer2.RemoveProducts(ids);
            Thread.Sleep(1000);

            string name;
            float price;
            int quantity;
            string platform;
            string genre;

            dataLayer2.GetProductById(0, out name, out price, out quantity, out platform, out genre);
            Assert.AreEqual(6, quantity);

            dataLayer2.GetProductById(1, out name, out price, out quantity, out platform, out genre);
            Assert.AreEqual(1, quantity);

            dataLayer2.GetProductById(2, out name, out price, out quantity, out platform, out genre);
            Assert.AreEqual(12, quantity);

            server.StopServer();
        }
    }
}