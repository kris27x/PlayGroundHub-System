using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FutBookClassLibrary;

namespace FutBookTesting
{
    [TestClass]
    public class tstBasketItem
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class clsBasketItem
            clsBasketItem basketItem = new clsBasketItem();
            //test to see that it exists
            Assert.IsNotNull(basketItem);
        }

        [TestMethod]
        public void StockNoPropertyOK()
        {
            //create an instance of the class clsBasketItem
            clsBasketItem basketItem = new clsBasketItem();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            basketItem.StockNo = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(basketItem.StockNo, TestData);
        }

        [TestMethod]
        public void QTYPropertyOK()
        {
            //create an instance of the class clsBasketItem
            clsBasketItem basketItem = new clsBasketItem();
            //create some test data to assign to the property
            Int32 TestData = 5;
            //assign the data to the property
            basketItem.QTY = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(basketItem.QTY, TestData);
        }

        [TestMethod]
        public void PricePropertyOK()
        {
            //create an instance of the class clsBasketItem
            clsBasketItem basketItem = new clsBasketItem();
            //create some test data to assign to the property
            decimal TestData = 10.99M;
            //assign the data to the property
            basketItem.Price = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(basketItem.Price, TestData);
        }
    }
}
