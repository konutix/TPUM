using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Diagnostics;

namespace DataUnitTests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void DataTesting()
        {
            IDataLayer dataLayer = IDataLayer.CreateDataLayer();
            Assert.IsNotNull(dataLayer);

            /* TESTY INTERGRACYJNE
            while (!(dataLayer.GetProductIds().Count > 0)) { }

            string name;
            float price;
            int quantity;
            string platform;
            string genre;

            dataLayer.GetProductById(1, out name, out price, out quantity, out platform, out genre);

            Assert.AreEqual(price, 150.0f);

            string shopName;
            string town;
            string street;
            int formed;
            bool active;

            dataLayer.GetShopData(out shopName, out town, out street, out formed, out active);

            Assert.AreEqual(shopName, "GameShop1");
            */
        }
    }
}