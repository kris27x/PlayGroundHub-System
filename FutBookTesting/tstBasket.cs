using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FutBookClassLibrary;

namespace FutBookTesting
{
    [TestClass]
    public class tstBasket
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class clsBasket
            clsBasket MyBasket = new clsBasket();
            //test to see that it exists
            Assert.IsNotNull(MyBasket);
        }

        [TestMethod]
        public void AccountNoPropertyOK()
        {
            //create an instance of the class clsBasket
            clsBasket MyBasket = new clsBasket();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            MyBasket.AccountNo = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyBasket.AccountNo, TestData);
        }
    }
}
