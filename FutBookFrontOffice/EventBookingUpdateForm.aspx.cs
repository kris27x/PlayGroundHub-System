using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class EventBookingUpdateForm : System.Web.UI.Page
    {
        //variable to store the primary key with page level scope
        Int32 BookingNo;

        //create an instance of the security class with page level scope
        clsSecurity Sec;

        private string GetFirstNameFromDatabase(int accountNo)
        {
            // Get the first name from the database using the AccountNo
            string firstName = Sec.GetFirstNameByAccountNo(accountNo);

            // Return the first name
            return firstName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //get the number of the Event to be processed
            BookingNo = Convert.ToInt32(Session["BookingNo"]);
            if (IsPostBack == false)
            {
                //if this is not a new record
                if (BookingNo != -1)
                {
                    //display the current data for the record
                    DisplayEvent();
                }
            }

            //on load get the current state from the session
            Sec = (clsSecurity)Session["Sec"];
            //if the object is null then it needs initialising
            if (Sec == null)
            {
                //initialise the object
                Sec = new clsSecurity();
                //update the session
                Session["Sec"] = Sec;
            }

            //set the state of the linsk based on the cureent state of authentication
            bool isAuthenticated = Sec.Authenticated;
            int accountNo = Convert.ToInt32(Session["AccountNo"]);
            bool isAdmin = Sec.IsAdmin;

            //If the user is not authenticated or not an admin, redirect to a default page
            if (!isAuthenticated || !isAdmin)
            {
                Response.Redirect("Permission.aspx");
            }

            SetLinks(Sec.Authenticated, Sec.IsAdmin);

            if (Sec.Authenticated)
            {
                // Get the AccountNo of the logged-in user from the session
                //int accountNo = Convert.ToInt32(Session["AccountNo"]);

                // Fetch the firstName from the database
                string firstName = GetFirstNameFromDatabase(accountNo);

                // Set the text of the lblGreeting
                lblGreeting.Text = $"Hello, {firstName}";
            }
            else
            {
                lblGreeting.Text = "";
            }


        }

        protected void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            //update Event
            Update();
        }

        private void SetLinks(Boolean Authenticated, Boolean IsAdmin)
        {
            ///sets the visiible state of the links based on the authentication state
            ///

            //set the state of the following to not authenticated i.e. they will be visible when not logged in
            hypSignUp.Visible = !Authenticated;
            hypSignIn.Visible = !Authenticated;
            //set the state of the following to authenticated i.e. they will be visible when user is logged in
            hypSignOut.Visible = Authenticated;
            hypAdmin.Visible = Authenticated && IsAdmin;
        }

        //function for updating records



        void Update()
        {
            //create an instance of the clsEventBookingCollection
            clsEventBookingCollection mEvent = new clsEventBookingCollection();
            //validate the data on the web form
            String Error = mEvent.ThisEvent.Valid(EventName.Text, EventDate.Text, SpecialRequests.Text, Participants.Value);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to update
                mEvent.ThisEvent.Find(BookingNo);
                //get the data entered by the user
                mEvent.ThisEvent.EventName = EventName.Text;
                mEvent.ThisEvent.EventDate = Convert.ToDateTime(EventDate.Text);
                mEvent.ThisEvent.SpecialRequests = SpecialRequests.Text;

                int participants;
                if (int.TryParse(Participants.Value, out participants))
                {
                    mEvent.ThisEvent.NumParticipants = participants;

                    // Calculate the price per person
                    decimal pricePerPerson = CalculatePricePerPerson(participants);

                    // Set the price per person in the event object
                    mEvent.ThisEvent.PricePerPerson = pricePerPerson;

                    // Calculate the total price and set it in the event object
                    mEvent.ThisEvent.TotalPrice = participants * pricePerPerson;

                    // Check whether the selected date is already booked
                    if (mEvent.IsDateAlreadyBooked(mEvent.ThisEvent.EventDate))
                    {
                        lblError.Text = "This date is already booked. Please select another date.";
                    }
                    else
                    {
                        // update the record
                        mEvent.Update();

                        // display success message
                        lblError.Text = "Event has been updated successfully.";
                    }
                }
                else
                {
                    lblError.Text = "There was a problem with the number of participants.";
                }
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered " + Error;
            }
        }





        //display Event
        void DisplayEvent()
        {
            //create an instance of the clsEventBookingCollection
            clsEventBookingCollection mEvent = new clsEventBookingCollection();
            //find the record to update
            mEvent.ThisEvent.Find(BookingNo);
            //display the data for this record
            EventName.Text = mEvent.ThisEvent.EventName;
            SpecialRequests.Text = mEvent.ThisEvent.SpecialRequests;
            Participants.Value = mEvent.ThisEvent.NumParticipants.ToString();
            EventDate.Text = mEvent.ThisEvent.EventDate.ToString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect to previous page
            Response.Redirect("EventBookingUpdate.aspx");
        }

        protected void btnUpdateEventBooking_Click(object sender, EventArgs e)
        {
            Update();
        }



        decimal CalculatePricePerPerson(int participants)
        {
            // logic to calculate the price per person based on the number of participants
            // over 10 participants there is an discount (18) per person, over 30 (15pp)
            if (participants >= 3 && participants <= 10)
            {
                return 20m;
            }
            else if (participants > 10 && participants <= 30)
            {
                return 18m;
            }
            else
            {
                return 15m;
            }
        }



    }
}