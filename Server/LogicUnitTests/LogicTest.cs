using Data;
using Logic;

namespace LogicUnitTests
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void LogicTesting()
        {
            ILogicLayer logicLayer = ILogicLayer.CreateLogicLayer(new DataInject());
            Assert.IsNotNull(logicLayer);

            string name;
            float price;
            int quantity;
            string platform;
            string genre;

            logicLayer.GetProductById(0, out name, out price, out quantity, out platform, out genre);

            Assert.AreEqual(price, 37.0f);
            Assert.AreEqual(quantity, 10.0f);
        }
    }

    internal class DataInject : IDataLayer
    {
        public override void AddExistingProduct(int id, int quant){}

        public override void AddNewProduct(string name, float price, int quantity, string platform, string genre){}

        public override void ChangePrice(int id, float newPrice){}

        public override void DrawData(){}

        public override void GetProductById(int id, out string name, out float price, out int quantity, out string platform, out string genre)
        {
            name = "testName";
            price = 37.0f;
            quantity = 10;
            platform = "testPlatform";
            genre = "testGenre";
        }

        public override List<int> GetProductIds()
        {
            return new List<int>();
        }

        public override void GetShopData(out string shopName, out string homeTown, out string street, out int formed, out bool active)
        {
            shopName = "testName";
            homeTown = "testTown";
            street = "testStreet";
            formed = 2024;
            active = true;
        }

        public override bool RemoveProduct(int id, int quant)
        {
            return true;
        }

        public override void SetShopData(string shopName, string homeTown, string street, int formed, bool active){}
    }
}