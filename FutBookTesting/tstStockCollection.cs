using FutBookClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FutBookTesting
{
    [TestClass]
    public class tstStockCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsStockCollection AllStock = new clsStockCollection();
            //test to see that it exists
            Assert.IsNotNull(AllStock);
        }

        [TestMethod]
        public void StockListOK()
        {
            //create an instance of the class clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //create some test data to assign to the property
            List<clsStock> TestList = new List<clsStock>();
            //add an item to the list
            //create the item of test data
            clsStock TestItem = new clsStock();
            //set its properties
            TestItem.StockNo = 1;
            TestItem.StockName = "Real Madrid T-Shirt";
            TestItem.StockCategory = "T-SHIRTS";
            TestItem.StockQuantity = 2;
            TestItem.StockPrice = 59.99m;
            //add the item to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllStock.StockList = TestList;
            //test to see that the two values are the same
            Assert.AreEqual(AllStock.StockList, TestList);
        }

        [TestMethod]
        public void ThisStockPropertyOK()
        {
            //create an instance of the class clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //create an instance of the class clsStock
            clsStock TestStock = new clsStock();
            //set the properties of the test object
            TestStock.StockNo = 1;
            TestStock.StockName = "Real Madrid T-Shirt";
            TestStock.StockCategory = "T-SHIRTS";
            TestStock.StockQuantity = 2;
            TestStock.StockPrice = 1000;
            //assign the data to the property
            AllStock.ThisStock = TestStock;
            //test to see that two values are the same
            Assert.AreEqual(AllStock.ThisStock, TestStock);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //create instance of the class we want to create
            clsStockCollection AllStock = new clsStockCollection();
            //create test data to assign to the property
            //in this case data needs to be a list of objects
            List<clsStock> TestList = new List<clsStock>();
            //add an item to the list 
            //creater the item of test data
            clsStock TestItem = new clsStock();
            //set its properties
            TestItem.StockNo = 1;
            TestItem.StockName = "Real Madrid T-Shirt";
            TestItem.StockCategory = "T-SHIRTS";
            TestItem.StockQuantity = 2;
            TestItem.StockPrice = 1000;
            //add the item to the test list
            TestList.Add(TestItem);
            //assign the data to property
            AllStock.StockList = TestList;
            //test to see that it exists
            Assert.AreEqual(AllStock.Count, TestList.Count);
        }


        /*[TestMethod]
        public void AddMethodOK()
        {
            //create an instance of the class clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //create an item of test data
            clsStock TestItem = new clsStock();
            //var to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.StockName = "Real Madrid T-Shirt";
            TestItem.StockCategory = "T-Shirts";
            TestItem.StockQuantity = 20;
            TestItem.StockPrice = 59;
            //set ThisStock to the test data
            AllStock.ThisStock = TestItem;
            //add the record
            PrimaryKey = AllStock.Add();
            //set the primary key of the test data
            TestItem.StockNo = PrimaryKey;
            //find the record
            AllStock.ThisStock.Find(PrimaryKey);
            //test to see that the values are the same
            Assert.AreEqual(AllStock.ThisStock, TestItem);
        }*/

        //[TestMethod]
        //public void DeleteMethodOK()
        //{
        //    //create an instance of the class clsStockCollection
        //    clsStockCollection AllStock = new clsStockCollection();
        //    //create an item of test data
        //    clsStock TestItem = new clsStock();
        //    //var to store the primary key
        //    Int32 PrimaryKey = 1;
        //    byte[] imageBytes = null;
        //    //set its properties
        //    TestItem.StockName = "Real Madrid T-Shirt";
        //    TestItem.StockCategory = "T-Shirts";
        //    TestItem.StockQuantity = 20;
        //    TestItem.StockPrice = 59;
        //    TestItem.StockImage = imageBytes;
        //    //set ThisStock to the test data
        //    AllStock.ThisStock = TestItem;
        //    //add the record
        //    PrimaryKey = AllStock.Add();
        //    //set the primary key of the test data
        //    TestItem.StockNo = PrimaryKey;
        //    //find the record
        //    AllStock.ThisStock.Find(PrimaryKey);
        //    //delete the record
        //    AllStock.Delete();
        //    //now find the record
        //    Boolean Found = AllStock.ThisStock.Find(PrimaryKey);
        //    //test to see that the record was not found
        //    Assert.IsFalse(Found);
        //}

        //[TestMethod]
        //public void UpdateMethodOK()
        //{
        //    //create an instance of the class clsStockCollection
        //    clsStockCollection AllStock = new clsStockCollection();
        //    //create an item of test data
        //    clsStock TestItem = new clsStock();
        //    //var to store the primary key
        //    Int32 PrimaryKey = 0;
        //    //set its properties
        //    TestItem.StockName = "Real Madrid T-Shirt";
        //    TestItem.StockCategory = "T-Shirts";
        //    TestItem.StockQuantity = 20;
        //    TestItem.StockPrice = 59;
        //    //set ThisStock to the test data
        //    AllStock.ThisStock = TestItem;
        //    //add the record
        //    PrimaryKey = AllStock.Add();
        //    //set the primary key of the test data
        //    TestItem.StockNo = PrimaryKey;
        //    //modify the test data
        //    TestItem.StockName = "Real Madrid T-Shirt";
        //    TestItem.StockCategory = "T-Shirts";
        //    TestItem.StockQuantity = 20;
        //    TestItem.StockPrice = 59;
        //    //set the record based on the new test data
        //    AllStock.ThisStock = TestItem;
        //    //update the record
        //    AllStock.Update();
        //    //find the record
        //    AllStock.ThisStock.Find(PrimaryKey);
        //    //test to see ThisStock matches the test data
        //    Assert.AreEqual(AllStock.ThisStock, TestItem);
        //}
    }
}
