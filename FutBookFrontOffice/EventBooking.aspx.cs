using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;
using System.Data.SqlClient;

namespace FutBookFrontOffice
{
    public partial class EventBooking : System.Web.UI.Page
    {
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

            // If the user is not authenticated or not an admin, redirect to a default page
            if (!isAuthenticated)
            {
                Response.Redirect("PermissionEventLogin.aspx");
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



        protected void btnBook_Click(object sender, EventArgs e)
        {

            Add();

        }



        void Add()
        {
            // Create an instance of the clsEventBookingCollection
            clsEventBookingCollection MyEventBookingCollection = new clsEventBookingCollection();

            // Validate the data on the web form
            String Error = MyEventBookingCollection.ThisEvent.Valid(
                EventName.Text,
                EventDate.Text,
                SpecialRequests.Text,
                Participants.Value
            );

            // If the data is OK, then add it to the object
            if (Error == "")
            {
                // Get the data entered by the user
                MyEventBookingCollection.ThisEvent.EventName = EventName.Text;
                MyEventBookingCollection.ThisEvent.EventDate = DateTime.Parse(EventDate.Text);
                MyEventBookingCollection.ThisEvent.SpecialRequests = SpecialRequests.Text;

                int participants;
                if (int.TryParse(Participants.Value, out participants))
                {
                    MyEventBookingCollection.ThisEvent.NumParticipants = participants;

                    // Calculate the price per person
                    decimal pricePerPerson = CalculatePricePerPerson(participants);

                    // Set the price per person in the event object
                    MyEventBookingCollection.ThisEvent.PricePerPerson = pricePerPerson;

                    // Calculate the total price and set it in the event object
                    MyEventBookingCollection.ThisEvent.TotalPrice = participants * pricePerPerson;

                    // Check whether the selected date is already booked
                    if (MyEventBookingCollection.IsDateAlreadyBooked(MyEventBookingCollection.ThisEvent.EventDate))
                    {
                        lblError.Text = "This date is already booked. Please select another date.";
                    }
                    else
                    {
                        // Add the record
                        MyEventBookingCollection.Add();

                        // Display success message
                        lblError.Text = "Event has been added successfully.";
                    }
                }
                else
                {
                    lblError.Text = "There was a problem with the number of participants.";
                }
            }
            else
            {
                // Report an error
                lblError.Text = "There was a problem " + Error;
            }
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
