using System;
using System.Data.SqlClient;


namespace FutBookClassLibrary
{
    public class clsEventBooking
    {
        private int mBookingNo;
        public int BookingNo
        {
            get { return mBookingNo; }
            set { mBookingNo = value; }
        }

        private string mEventName;
        public string EventName
        {
            get { return mEventName; }
            set { mEventName = value; }
        }

        private DateTime mEventDate;
        public DateTime EventDate
        {
            get { return mEventDate; }
            set { mEventDate = value; }
        }

        private string mSpecialRequests;
        public string SpecialRequests
        {
            get { return mSpecialRequests; }
            set { mSpecialRequests = value; }
        }

        private int mNumParticipants;
        public int NumParticipants
        {
            get { return mNumParticipants; }
            set { mNumParticipants = value; }
        }

        private decimal mPricePerPerson;
        public decimal PricePerPerson
        {
            get { return mPricePerPerson; }
            set { mPricePerPerson = value; }
        }

        private decimal mTotalPrice;
        public decimal TotalPrice
        {
            get { return mTotalPrice; }
            set { mTotalPrice = value; }
        }


        public bool Find(int BookingNo)
        {
            // Create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();

            // Add the parameter for the booking number to search for
            DB.AddParameter("@BookingNo", BookingNo);

            // Execute the stored procedure
            DB.Execute("sproc_tblEventBooking_FilterByBookingNo");

            // If one record is found (there should be either one or zero)
            if (DB.Count == 1)
            {
                // Copy the data from the database to the private data members
                mBookingNo = Convert.ToInt32(DB.DataTable.Rows[0]["BookingNo"]);
                mEventName = Convert.ToString(DB.DataTable.Rows[0]["EventName"]);
                mEventDate = Convert.ToDateTime(DB.DataTable.Rows[0]["EventDate"]);
                mSpecialRequests = Convert.ToString(DB.DataTable.Rows[0]["SpecialRequests"]);
                mNumParticipants = Convert.ToInt32(DB.DataTable.Rows[0]["NumParticipants"]);
                mPricePerPerson = Convert.ToDecimal(DB.DataTable.Rows[0]["PricePerPerson"]);
                mTotalPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["TotalPrice"]);

                // Return that everything worked OK
                return true;
            }
            // If no record was found
            else
            {
                // Return false indicating problem
                return false;
            }
        }


        public string Valid(string EventName, string EventDate, string SpecialRequests, string NumParticipants)
        {
            // Create a string variable to store the error
            String Error = "";

            // Create a variable for the number of participants
            int numParticipants;

            // If the EventName is blank
            if (EventName.Length == 0)
            {
                // Record the error
                Error = Error + "The event name may not be blank: ";
            }
            // If the EventName is greater than 50 characters
            if (EventName.Length > 50)
            {
                // Record the error
                Error = Error + "The event name must be less than 50 characters: ";
            }

            //// If the EventDate is not a valid EventDate
            //DateTime tempEventDate;
            //if (!DateTime.TryParse(EventDate, out tempEventDate))
            //{
            //    // Record the error
            //    Error = Error + "The EventDate must be a valid EventDate: ";
            //}

            // If the EventDate is blank
            if (EventDate.Length == 0)
            {
                // Record the error
                Error += "The EventDate may not be blank. ";
            }
            else
            {
                // Convert the eventDate string to a DateTime object
                DateTime tempEventDate;
                if (!DateTime.TryParse(EventDate, out tempEventDate))
                {
                    // Record the error
                    Error += "The EventDate must be a valid date. ";
                }
                else
                {
                    // Check if the event date is already booked
                    clsDataConnection DB = new clsDataConnection();
                    DB.AddParameter("@EventDate", tempEventDate.Date);
                    int count = Convert.ToInt32(DB.Execute("sproc_tblEventBooking_CountByEventDate"));

                    if (count > 0)
                    {
                        Error += "The selected date is already booked. ";
                    }
                }
            }




            // If the SpecialRequests is greater than 250 characters
            if (SpecialRequests.Length > 250)
            {
                // Record the error
                Error = Error + "The special requests must be less than 250 characters: ";
            }

            // If the NumParticipants is not a valid number or less than 3
            if (!Int32.TryParse(NumParticipants, out numParticipants) || numParticipants < 3)
            {
                // Record the error
                Error = Error + "The number of participants must be  greater than 3 ";
            }

            // Return any error messages
            return Error;
        }
    }
}