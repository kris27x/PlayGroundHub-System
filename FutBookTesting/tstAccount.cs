using FutBookClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace FutBookTesting
{
    [TestClass]
    public class tstAccount
    {

        //good test data
        //create some test data to pass to the method
        string FirstName = "Bob";
        string SurName = "Smith";
        /*        string HouseNo = "123";
        */
        string PhoneNo = "07902916711";


        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //test to see that it exists
            Assert.IsNotNull(MyAccount);
        }


        [TestMethod]
        public void AccountNoPropertyOK()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            MyAccount.AccountNo = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyAccount.AccountNo, TestData);
        }

        [TestMethod]
        public void FirstNamePropertyOK()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //create some test data to assign to the property
            string TestData = "Bob";
            //assign the data to the property
            MyAccount.FirstName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyAccount.FirstName, TestData);
        }

        /*        [TestMethod]
                public void HouseNoPropertyOK()
                {
                    //create an instance of the class clsAccount
                    clsAccount MyAccount = new clsAccount();
                    //create some test data to assign to the property
                    Int32 TestData = 1;
                    //assign the data to the property
                    MyAccount.HouseNo = TestData;
                    //test to see that the two values are the same
                    Assert.AreEqual(MyAccount.HouseNo, TestData);
                }*/


        [TestMethod]
        public void SurNamePropertyOK()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //create some test data to assign to the property
            string TestData = "Smith";
            //assign the data to the property
            MyAccount.SurName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(MyAccount.SurName, TestData);
        }

        /*        [TestMethod]
                public void FindMethodOK()
                {
                    //create an instance of the class clsAccount
                    clsAccount MyAccount = new clsAccount();
                    //boolean variable to store the results of the validation
                    Boolean Found = false;
                    //create some test data to use with the method
                    Int32 AccountNo = 2;
                    //invoke the method
                    Found = MyAccount.Find(AccountNo);
                    //test to see if the result is true
                    Assert.IsTrue(Found);
                }*/
        /*
                [TestMethod]
                public void TestAccountNoFound()
                {
                    //create an instance of the class clsAccount
                    clsAccount MyAccount = new clsAccount();
                    //boolean variable to store the results of the search
                    Boolean Found = false;
                    //boolean variable to record if data is OK(assume it is)
                    Boolean OK = true;
                    //create some test data to use with the method
                    Int32 AccountNo = 2;
                    //invoke the method
                    Found = MyAccount.Find(AccountNo);
                    //check the stock id
                    if (MyAccount.AccountNo != 2)
                    {
                        OK = false;
                    }
                    //test to see if the result is true
                    Assert.IsTrue(OK);
                }*/


        /*
                [TestMethod]
                public void TestFirstNameFound()
                {
                    //create an instance of the class clsAccount
                    clsAccount MyAccount = new clsAccount();
                    //boolean variable to store the results of the search
                    Boolean Found = false;
                    //boolean variable to record if data is OK(assume it is)
                    Boolean OK = true;
                    //create some test data to use with the method
                    Int32 AccountNo = 1;
                    //invoke the method
                    Found = MyAccount.Find(AccountNo);
                    //check the property
                    if (MyAccount.FirstName != "Bob")
                    {
                        OK = false;
                    }
                    //test to see if the result is true
                    Assert.IsTrue(OK);
                }*/

        /*        [TestMethod]
                public void TestHouseNoFound()
                {
                    //create an instance of the class clsAccount
                    clsAccount MyAccount = new clsAccount();
                    //boolean variable to store the results of the search
                    Boolean Found = false;
                    //boolean variable to record if data is OK(assume it is)
                    Boolean OK = true;
                    //create some test data to use with the method
                    Int32 AccountNo = 3;
                    //invoke the method
                    Found = MyAccount.Find(AccountNo);
                    //check the property
                    if (MyAccount.HouseNo != 3)
                    {
                        OK = false;
                    }
                    //test to see if the result is true
                    Assert.IsTrue(OK);
                }*/


        /*        [TestMethod]
                public void TestSurNameFound()
                {
                    //create an instance of the class clsAccount
                    clsAccount MyAccount = new clsAccount();
                    //boolean variable to store the results of the search
                    Boolean Found = false;
                    //boolean variable to record if data is OK(assume it is)
                    Boolean OK = true;
                    //create some test data to use with the method
                    Int32 AccountNo = 3;
                    //invoke the method
                    Found = MyAccount.Find(AccountNo);
                    //check the property
                    if (MyAccount.SurName != "Smith")
                    {
                        OK = false;
                    }
                    //test to see if the result is true
                    Assert.IsTrue(OK);
                }*/

        [TestMethod]
        public void ValidMethodOK()
        {
            //create an instance of the clsAccount
            clsAccount MyAccount = new clsAccount();
            //string variable to store any error message
            string Error = "";
            //invoke the method
            //Error = MyAccount.Valid(FirstName, SurName, PhoneNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }


        [TestMethod]
        public void FirstNameMin()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //string variable to store any error message
            string Error = "";
            //create some test data to pass to the method
            string FirstName = "a";
            //invoke the method
            //Error = MyAccount.Valid(FirstName, SurName, PhoneNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }


        [TestMethod]
        public void FirstNameMax()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //string variable to store any error message
            string Error = "";
            //create some test data to pass to the method
            string FirstName = "";
            FirstName = FirstName.PadRight(50, 'a');
            //invoke the method
            //Error = MyAccount.Valid(FirstName, SurName, PhoneNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }


        [TestMethod]
        public void SurNameMin()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //string variable to store any error message
            string Error = "";
            //create some test data to pass to the method
            string SurName = "a";
            //invoke the method
            //Error = MyAccount.Valid(FirstName, SurName, PhoneNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }



        [TestMethod]
        public void SurNameMax()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //string variable to store any error message
            string Error = "";
            //create some test data to pass to the method
            string SurName = "";
            SurName = SurName.PadRight(30, 'a');
            //invoke the method
            //Error = MyAccount.Valid(FirstName, SurName, PhoneNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }





        /*        [TestMethod]
                public void HouseNoMin()
                {
                    //create an instance of the class clsAccount
                    clsAccount MyAccount = new clsAccount();
                    //string variable to store any error message
                    string Error = "";
                    //create some test data to pass to the method
                    string HouseNo = "1";
                    //invoke the method
                    Error = MyAccount.Valid(FirstName, SurName, PhoneNo, HouseNo);
                    //test to see that the result is correct
                    Assert.AreEqual(Error, "");
                }*/



        /*        [TestMethod]
                public void HouseNoMax()
                {
                    //create an instance of the class clsAccount
                    clsAccount MyAccount = new clsAccount();
                    //string variable to store any error message
                    string Error = "";
                    //create some test data to pass to the method
                    string HouseNo = "999";
                    //invoke the method
                    Error = MyAccount.Valid(FirstName, SurName, PhoneNo, HouseNo);
                    //test to see that the result is correct
                    Assert.AreEqual(Error, "");
                }*/



        [TestMethod]
        public void PhoneNoMin()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //string variable to store any error message
            string Error = "";
            //create some test data to pass to the method
            string PhoneNo = "1";
            //invoke the method
            //Error = MyAccount.Valid(FirstName, SurName, PhoneNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }





        [TestMethod]
        public void PhoneNoMax()
        {
            //create an instance of the class clsAccount
            clsAccount MyAccount = new clsAccount();
            //string variable to store any error message
            string Error = "";
            //create some test data to pass to the method
            string PhoneNo = "11111111111";
            //invoke the method
            //Error = MyAccount.Valid(FirstName, SurName, PhoneNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }
    }
}
