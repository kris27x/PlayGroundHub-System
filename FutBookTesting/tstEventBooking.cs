//using NUnit.Framework;
//using System;

//namespace FutBookClassLibrary.Tests
//{
//    public class tstEventBooking
//    {
//        private clsEventBooking _eventBooking;

//        [SetUp]
//        public void Setup()
//        {
//            _eventBooking = new clsEventBooking();
//        }

//        [Test]
//        public void EventName_MinusOneCharacter_ShouldReturnError()
//        {
//            var result = _eventBooking.Valid("", "01/01/2023", "", "5");
//            Assert.That(result, Does.Contain("The event name may not be blank"));
//        }

//        [Test]
//        public void EventName_MaximumPlusOneCharacter_ShouldReturnError()
//        {
//            var longName = new string('a', 51);
//            var result = _eventBooking.Valid(longName, "01/01/2023", "", "5");
//            Assert.That(result, Does.Contain("The event name must be less than 50 characters"));
//        }

//        [Test]
//        public void Valid_InvalidDataType_ShouldReturnError()
//        {
//            var result = _eventBooking.Valid("Event", "invalid date", "", "invalid number");
//            Assert.That(result, Does.Contain("The EventDate must be a valid date"));
//            Assert.That(result, Does.Contain("The number of participants must be  greater than 3"));
//        }

//        [Test]
//        public void Find_InvalidBookingNumber_ShouldReturnFalse()
//        {
//            var result = _eventBooking.Find(-1);
//            Assert.That(result, Is.False);
//        }
//    }
//}


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FutBookClassLibrary;

namespace FutBookTests
{
    [TestClass]
    public class tstEventBooking
    {
        [TestMethod]
        public void FindMethodOk()
        {
            // Create an instance of the class we want to create
            clsEventBooking AEventBooking = new clsEventBooking();

            // Boolean variable to store the result of the search
            Boolean Found = false;

            // Create some test data to use with the method
            int BookingNo = 33;

            // Invoke the method
            Found = AEventBooking.Find(BookingNo);

            // Test to see that the result is correct
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void EventNameMinLessOne()
        {
            // Create an instance of the class we want to create
            clsEventBooking AEventBooking = new clsEventBooking();

            // String variable to store any error message
            String Error = "";

            // Create some test data to pass to the method
            string eventName = ""; // This should trigger an error

            Error = AEventBooking.Valid(eventName, "2023-06-15", "No special requests", "5");

            // Test to see that the result is correct
            Assert.AreEqual("The event name may not be blank: ", Error);
        }

        [TestMethod]
        public void EventNameMaxPlusOne()
        {
            // Create an instance of the class we want to create
            clsEventBooking AEventBooking = new clsEventBooking();

            // String variable to store any error message
            String Error = "";

            // Create some test data to pass to the method
            string eventName = new string('A', 51); // This should trigger an error

            Error = AEventBooking.Valid(eventName, "2023-06-15", "No special requests", "5");

            // Test to see that the result is correct
            Assert.AreEqual("The event name must be less than 50 characters: ", Error);
        }

        [TestMethod]
        public void EventDateInvalidData()
        {
            // Create an instance of the class we want to create
            clsEventBooking AEventBooking = new clsEventBooking();

            // String variable to store any error message
            String Error = "";

            // Create some test data to pass to the method
            string eventDate = "This is not a date!"; // This should trigger an error

            Error = AEventBooking.Valid("Event Name", eventDate, "No special requests", "5");

            // Test to see that the result is correct
            Assert.AreEqual("The EventDate must be a valid date. ", Error);
        }

        [TestMethod]
        public void SpecialRequestsMaxPlusOne()
        {
            // Create an instance of the class we want to create
            clsEventBooking AEventBooking = new clsEventBooking();

            // String variable to store any error message
            String Error = "";

            // Create some test data to pass to the method
            string specialRequests = new string('A', 251); // This should trigger an error

            Error = AEventBooking.Valid("Event Name", "2023-06-15", specialRequests, "5");

            // Test to see that the result is correct
            Assert.AreEqual("The special requests must be less than 250 characters: ", Error);
        }

        [TestMethod]
        public void NumParticipantsLessThanThree()
        {// Create an instance of the class we want to create
            clsEventBooking AEventBooking = new clsEventBooking();

            // String variable to store any error message
            String Error = "";

            // Create some test data to pass to the method
            string numParticipants = "2"; // This should trigger an error

            Error = AEventBooking.Valid("Event Name", "2023-06-15", "No special requests", numParticipants);

            // Test to see that the result is correct
            Assert.AreEqual("The number of participants must be  greater than 3 ", Error);
        }

        [TestMethod]
        public void NumParticipantsNonNumeric()
        {
            // Create an instance of the class we want to create
            clsEventBooking AEventBooking = new clsEventBooking();

            // String variable to store any error message
            String Error = "";

            // Create some test data to pass to the method
            string numParticipants = "This is not a number!"; // This should trigger an error

            Error = AEventBooking.Valid("Event Name", "2023-06-15", "No special requests", numParticipants);

            // Test to see that the result is correct
            Assert.AreEqual("The number of participants must be  greater than 3 ", Error);
        }
    }
}



