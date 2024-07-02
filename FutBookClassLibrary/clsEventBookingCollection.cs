using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace FutBookClassLibrary
{
    public class clsEventBookingCollection
    {
        //private data member for the list
        List<clsEventBooking> mEventList = new List<clsEventBooking>();
        //private data member thisEvent
        clsEventBooking mThisEvent = new clsEventBooking();

        //constructor for the class
        public clsEventBookingCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblEventBooking_SelectAll");
            //populate the array list with the data table
            PopulateArray(DB);

        }

        //public property for the event list
        public List<clsEventBooking> EventList
        {
            get
            {
                //return the private data
                return mEventList;
            }
            set
            {
                //set the private data
                mEventList = value;
            }
        }

        public int Count
        {
            get
            {
                //return the count of the list
                return mEventList.Count;
            }
            set
            {
                //
            }
        }
        public clsEventBooking ThisEvent
        {
            get
            {
                //return the private data
                return mThisEvent;
            }
            set
            {
                //set the private data
                mThisEvent = value;
            }
        }

        public bool IsDateAlreadyBooked(DateTime eventDate)
        {
            // Create a new instance of the data connection class
            clsDataConnection DB = new clsDataConnection();

            // Add the parameter for the event date
            DB.AddParameter("@EventDate", eventDate);

            // Execute the stored procedure to count the number of bookings for the event date
            int count = Convert.ToInt32(DB.Execute("sproc_tblEventBooking_CountByEventDate"));

            // If the count is greater than 0, the date is already booked
            return count > 0;
        }

        public int Add()
        {
            //adds a new record to the database based on the values of mThisEvent
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@EventName", mThisEvent.EventName);
            DB.AddParameter("@EventDate", mThisEvent.EventDate);
            DB.AddParameter("@SpecialRequests", mThisEvent.SpecialRequests);
            DB.AddParameter("@NumParticipants", mThisEvent.NumParticipants);
            DB.AddParameter("@PricePerPerson", mThisEvent.PricePerPerson);
            DB.AddParameter("@TotalPrice", mThisEvent.TotalPrice);


            //execute the query returning the primary key value
            return DB.Execute("sproc_EventBookingAdd");

        }






        public void Delete()
        {
            // deletes the record pointed to by thisEvent
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@BookingNo", mThisEvent.BookingNo);
            //execute the stored procedure
            DB.Execute("sproc_tblEvent_Delete");
        }

        void PopulateArray(clsDataConnection DB)
        {
            //populates the array list based on the data table in the parameter DB
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount;
            //get the count of records
            RecordCount = DB.Count;
            //clear the private array list
            mEventList = new List<clsEventBooking>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsEventBooking MyEvent = new clsEventBooking();
                //read in the fields from the current record
                MyEvent.BookingNo = Convert.ToInt32(DB.DataTable.Rows[Index]["BookingNo"]);
                MyEvent.EventDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["EventDate"]);

                MyEvent.EventName = Convert.ToString(DB.DataTable.Rows[Index]["EventName"]);
                MyEvent.PricePerPerson = Convert.ToInt32(DB.DataTable.Rows[Index]["PricePerPerson"]);
                MyEvent.TotalPrice = Convert.ToInt32(DB.DataTable.Rows[Index]["TotalPrice"]);

                MyEvent.NumParticipants = Convert.ToInt32(DB.DataTable.Rows[Index]["NumParticipants"]);
                //add the record to the private data member
                mEventList.Add(MyEvent);
                //point at the next record
                Index++;
            }
        }

        public void Update()
        {
            //update an existing record based on the values of thisEvent
            //connect to database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@BookingNo", mThisEvent.BookingNo);
            DB.AddParameter("@EventName", mThisEvent.EventName);
            DB.AddParameter("@EventDate", mThisEvent.EventDate);
            DB.AddParameter("@SpecialRequests", mThisEvent.SpecialRequests);
            DB.AddParameter("@NumParticipants", mThisEvent.NumParticipants);
            DB.AddParameter("@PricePerPerson", mThisEvent.PricePerPerson);
            DB.AddParameter("@TotalPrice", mThisEvent.TotalPrice);

            
            




            //execute the stored procedure
            DB.Execute("sproc_tblEventBookingUpdate");
        }


        public void FetchAll()
        {
            // Clear the current EventList
            EventList.Clear();

            // Create an instance of clsDataConnection
            clsDataConnection DB = new clsDataConnection();

            // Execute the query and read the results
            DB.Execute("sproc_tblEventBooking_SelectAll");

            // Loop through the rows of the DataTable and create clsEventBooking objects
            foreach (DataRow row in DB.DataTable.Rows)
            {
                clsEventBooking eventBooking = new clsEventBooking();
                eventBooking.BookingNo = Convert.ToInt32(row["BookingNo"]);
                eventBooking.EventName = Convert.ToString(row["EventName"]);
                eventBooking.EventDate = Convert.ToDateTime(row["EventDate"]);
                eventBooking.SpecialRequests = Convert.ToString(row["SpecialRequests"]);
                eventBooking.NumParticipants = Convert.ToInt32(row["NumParticipants"]);
                eventBooking.PricePerPerson = Convert.ToDecimal(row["PricePerPerson"]);
                eventBooking.TotalPrice = Convert.ToDecimal(row["TotalPrice"]);



                EventList.Add(eventBooking);
            }
        }



    }
}