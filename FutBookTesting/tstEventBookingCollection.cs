using Microsoft.VisualStudio.TestTools.UnitTesting;
using FutBookClassLibrary;
using System;
using System.Collections.Generic;

namespace FutBookTesting
{
    [TestClass]
    public class tstEventBookingCollection
    {
        [TestMethod]
        public void Test_Add()
        {
            // Arrange
            clsEventBookingCollection collection = new clsEventBookingCollection();
            int initialCount = collection.Count;

            // Create a mock version of clsEventBooking and set its properties
            clsEventBooking mockEvent = new clsEventBooking();
            mockEvent.BookingNo = 1;
            mockEvent.EventName = "Test Event";
            mockEvent.EventDate = DateTime.Now;
            mockEvent.SpecialRequests = "None";
            mockEvent.NumParticipants = 5;
            mockEvent.PricePerPerson = 20;
            mockEvent.TotalPrice = 100;

            collection.ThisEvent = mockEvent;

            // Act
            collection.Add();

            // Assert
            Assert.IsTrue(collection.Count > initialCount);
        }

        [TestMethod]
        public void Test_Delete()
        {
            // Arrange
            clsEventBookingCollection collection = new clsEventBookingCollection();

            // Assumption: The collection must have at least one item
            Assert.IsTrue(collection.Count > 0);

            // Set ThisEvent to the first item in the collection
            collection.ThisEvent = collection.EventList[0];

            // Remember the BookingNo of the event we're about to delete
            int bookingNoToDelete = collection.ThisEvent.BookingNo;

            // Act
            collection.Delete();

            // Assert
            // Ensure that there is no event left in the collection with the deleted BookingNo
            Assert.IsFalse(collection.EventList.Exists(e => e.BookingNo == bookingNoToDelete));
        }

        [TestMethod]
        public void Test_Update()
        {
            // Arrange
            clsEventBookingCollection collection = new clsEventBookingCollection();

            // Assumption: The collection must have at least one item
            Assert.IsTrue(collection.Count > 0);

            // Set ThisEvent to the first item in the collection
            collection.ThisEvent = collection.EventList[0];

            // Change a property
            string updatedEventName = "Updated Event Name";
            collection.ThisEvent.EventName = updatedEventName;

            // Act
            collection.Update();

            // Assert
            // Ensure that the event in the collection now has the updated event name
            Assert.AreEqual(updatedEventName, collection.EventList[0].EventName);
        }

    }
}
