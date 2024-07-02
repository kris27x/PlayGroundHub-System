using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FutBookClassLibrary;

namespace FutBookTesting
{
    [TestClass]
    public class tstStock
    {

        //good test data
        //create some test data to pass to the method
        string StockName = "Real Madrid T-Shirt";
        string StockPrice = "59.99";
        string StockCategory = "T-SHIRTS";
        string StockQuantity = "20";

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //test to see that it exists
            Assert.IsNotNull(MyStock);
        }

        [TestMethod]
        public void StockNoPropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            MyStock.StockNo = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockNo, TestData);
        }

        [TestMethod]
        public void StockNamePropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            string TestData = "abc";
            //assign the data to the property
            MyStock.StockName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockName, TestData);
        }

        [TestMethod]
        public void StockQuantityPropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            MyStock.StockQuantity = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockQuantity, TestData);
        }

        [TestMethod]
        public void StockPricePropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            decimal TestData = 100;
            //assign the data to the property
            MyStock.StockPrice = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockPrice, TestData);
        }

        [TestMethod]
        public void StockCategoryPropertyOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            string TestData = "abc";
            //assign the data to the property
            MyStock.StockCategory = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyStock.StockCategory, TestData);
        }

        //[TestMethod]
        //public void StockImagePropertyOK()
        //{
            //create an instance of the class clsStock
            //clsStock MyStock = new clsStock();
            //create some test data to assign to the property
            //byte[] TestData = new byte[] { 0x1A, 0x2B, 0x3C };
            //assign the data to the property
            //MyStock.StockImage = TestData;
            //test to see that the two values are the same
            //Assert.AreEqual(MyStock.StockImage, TestData);
       // }

        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //boolean variable to store the results of the validation
            Boolean Found = false;
            //create some test data to use with the method
            Int32 StockNo = 1;
            //invoke the method
            Found = MyStock.Find(StockNo);
            //test to see if the result is true
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestStockNoFound()
        {
            //create an instance of the class clsStock
            clsStock MyStock = new clsStock();
            //boolean variable to store the results of the search
            Boolean Found = false;
            //boolean variable to record if data is OK(assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 StockNo = 1;
            //invoke the method
            Found = MyStock.Find(StockNo);
            //check the stock id
            if (MyStock.StockNo != 1)
            {
                OK = false;
            }
            //test to see if the result is true
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void ValidMethodOK()
        {
            //create an instance of the class clsStock
            clsStock stock = new clsStock();
            //create a string variable to store any error message
            string Error = "";
            //create some test data to use with the method
            string stockName = "Test Stock";
            string stockPrice = "24";
            string stockQuantity = "10";
            string stockCategory = "Category";
            byte[] stockImage = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            //invoke the method
            Error = stock.Valid(stockName, stockPrice, stockQuantity, stockCategory, stockImage);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        // Tests for StockName
        [TestMethod]
        public void StockNameMin()
        {
            clsStock stock = new clsStock();
            string Error = "";
            string stockName = ""; // Minimum  condition
            string stockPrice = "100";
            string stockQuantity = "10";
            string stockCategory = "Category";
            byte[] stockImage = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            Error = stock.Valid(stockName, stockPrice, stockQuantity, stockCategory, stockImage);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StockNameMaxPlusOne() 
        {
            clsStock stock = new clsStock();
            string Error = "";
            string stockName = new string('a', 51); // Maximum plus one
            string stockPrice = "100";
            string stockQuantity = "10";
            string stockCategory = "Category";
            byte[] stockImage = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            Error = stock.Valid(stockName, stockPrice, stockQuantity, stockCategory, stockImage);
            Assert.AreNotEqual(Error, "");
        }

        //Tests for StockPrice
        [TestMethod]
        public void StockPriceInvalidData()
        {
            clsStock stock = new clsStock();
            string Error = "";
            string stockName = "Test Stock";
            string stockPrice = "invalid"; // Invalid data
            string stockQuantity = "10";
            string stockCategory = "Category";
            byte[] stockImage = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            Error = stock.Valid(stockName, stockPrice, stockQuantity, stockCategory, stockImage);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StockPriceGreaterThanMax()
        {
            clsStock stock = new clsStock();
            string Error = "";
            string stockName = "Test Stock";
            string stockPrice = "100001"; // Greater than maximum
            string stockQuantity = "10";
            string stockCategory = "Category";
            byte[] stockImage = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            Error = stock.Valid(stockName, stockPrice, stockQuantity, stockCategory, stockImage);
            Assert.AreNotEqual(Error, "");
        }

        // Tests for StockCategory
        [TestMethod]
        public void StockCategoryMin()
        {
            clsStock stock = new clsStock();
            string Error = "";
            string stockName = "Test Stock";
            string stockPrice = "100";
            string stockQuantity = "10";
            string stockCategory = ""; // Minimum condition
            byte[] stockImage = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            Error = stock.Valid(stockName, stockPrice, stockQuantity, stockCategory, stockImage);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StockCategoryMaxPlusOne()
        {
            clsStock stock = new clsStock();
            string Error = "";
            string stockName = "Test Stock";
            string stockPrice = "100";
            string stockQuantity = "10";
            string stockCategory = new string('a', 31); // Maximum plus one
            byte[] stockImage = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            Error = stock.Valid(stockName, stockPrice, stockQuantity, stockCategory, stockImage);
            Assert.AreNotEqual(Error, "");
        }

        //Tests for StockQuantity
        [TestMethod]
        public void StockQuantityInvalidData()
        {
            clsStock stock = new clsStock();
            string Error = "";
            string stockName = "Test Stock";
            string stockPrice = "100";
            string stockQuantity = "invalid"; // Invalid data
            string stockCategory = "Category";
            byte[] stockImage = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            Error = stock.Valid(stockName, stockPrice, stockQuantity, stockCategory, stockImage);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StockQuantityGreaterThanMax()
        {
            clsStock stock = new clsStock();
            string Error = "";
            string stockName = "Test Stock";
            string stockPrice = "100";
            string stockQuantity = "10000"; // Greater than maximum
            string stockCategory = "Category";
            byte[] stockImage = new byte[] { 0x20, 0x20, 0x20, 0x20 };
            Error = stock.Valid(stockName, stockPrice, stockQuantity, stockCategory, stockImage);
            Assert.AreNotEqual(Error, "");
        }


        
    }
}
