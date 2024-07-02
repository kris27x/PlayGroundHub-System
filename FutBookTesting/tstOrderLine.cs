using FutBookClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FutBookTesting
{
    [TestClass]
    public class tstOrderLine
    {
        [TestMethod]
        public void InstantiationOk()
        {
            //create an instance of the class
            clsOrderLine AOrderLine = new clsOrderLine();
        }

        [TestMethod]
        //used to test the OrderLineNo property of the class
        public void OrderLineNo()
        {
            //create an instance of the class
            clsOrderLine AOrderLine = new clsOrderLine();
            //create a variable to store the OrderLineNo
            Int32 OrderLineNo;
            //assign a value to the variable
            OrderLineNo = 11;
            //try to send some data to the OrderLineNo property
            AOrderLine.OrderLineNo = OrderLineNo;
            //check to see that the data in the variable and the property are the same
            Assert.AreEqual(AOrderLine.OrderLineNo, OrderLineNo);
        }

        [TestMethod]
        //used to test the OrderTotalPrice property of the class
        public void OrderTotalPrice()
        {
            //create an instance of the class
            clsOrderLine AOrderLine = new clsOrderLine();
            //create a variable to store the OrderTotalPrice
            double OrderTotalPrice;
            //assign a value to the variable
            OrderTotalPrice = 22.22;
            //try to send some data to the OrderTotalPrice property
            AOrderLine.OrderTotalPrice = OrderTotalPrice;
            //check to see that the data in the variable and the property are the same
            Assert.AreEqual(AOrderLine.OrderTotalPrice, OrderTotalPrice);
        }

        [TestMethod]
        //used to test the OrderLineQuantity property of the class
        public void OrderLineQuantity()
        {
            //create an instance of the class
            clsOrderLine AOrderLine = new clsOrderLine();
            //create a variable to store the OrderLineQuantity
            Int32 OrderLineQuantity;
            //assign a value to the variable
            OrderLineQuantity = 22;
            //try to send some data to the OrderLineQuantity property
            AOrderLine.OrderLineQuantity = OrderLineQuantity;
            //check to see that the data in the variable and the property are the same
            Assert.AreEqual(AOrderLine.OrderLineQuantity, OrderLineQuantity);
        }

        [TestMethod]
        //used to test the presence of the valid method
        public void Valid()
        {
            //create an instance of the class
            clsOrderLine AOrderLine = new clsOrderLine();
            //variable to store the test data
            string TestValue = "";
            //test to see if the valid method exists
            AOrderLine.Valid(TestValue);
        }

        [TestMethod]
        //used to test that field is not empty
        public void OrderLineQuantityNotEmpty()
        {
            //create an instance of the class
            clsOrderLine AOrderLine = new clsOrderLine();
            //create a variable to record the result of the validation test
            Boolean OK;
            //variable to store the test data
            string TestValue = "";
            //test the valid method with a blank string
            OK = AOrderLine.Valid(TestValue);
            //assert that the outcome should be false
            Assert.IsFalse(OK);
        }

        [TestMethod]
        //used to test that field is not empty
        public void OrderLineQuantityMax()
        {
            //create an instance of the class
            clsOrderLine AOrderLine = new clsOrderLine();
            //create a variable to record the result of the validation test
            Boolean OK;
            //variable to store the test data
            string TestValue = "";
            //pad the data to the required number of characters
            TestValue = TestValue.PadLeft(8);
            //test the valid method with a blank string
            OK = AOrderLine.Valid(TestValue);
            //assert that the outcome should be false
            Assert.IsFalse(OK);
        }
    }
}
