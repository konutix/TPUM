using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

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
        }
    }
}