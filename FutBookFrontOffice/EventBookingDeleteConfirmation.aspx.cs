using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class EventBookingDeleteConfirmation : System.Web.UI.Page
    {
        //create an instance of the security class with page level scope
        clsSecurity Sec;

        //var to store the primary key value of the record to be deleted
        Int32 BookingNo;

        private string GetFirstNameFromDatabase(int accountNo)
        {
            // Get the first name from the database using the AccountNo
            string firstName = Sec.GetFirstNameByAccountNo(accountNo);

            // Return the first name
            return firstName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //get the number of the stock to be deleted from the session object
            BookingNo = Convert.ToInt32(Session["BookingNo"]);
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

        //function to delete the selected record
        void DeleteEvent()
        {
            //create a new instance of the clsStockCollection
            clsEventBookingCollection MyEvent = new clsEventBookingCollection();
            //find the record to be deleted
            MyEvent.ThisEvent.Find(BookingNo);
            //delete the record
            MyEvent.Delete();
        }

        protected void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            //delete the record
            DeleteEvent();
            //redirect back to the previous page
            Response.Redirect("EventBookingDelete.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect to previous page
            Response.Redirect("EventBookingDelete.aspx");
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



    }
}