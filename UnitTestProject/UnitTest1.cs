using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
                Class1 clas = new Class1 { };
                Assert.IsNotNull(clas.Add(4, 5));
      
        }
    }

}
