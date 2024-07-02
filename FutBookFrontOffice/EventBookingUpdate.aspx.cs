using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class EventBookingUpdate : System.Web.UI.Page
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
            // On load, get the current state from the session
            Sec = (clsSecurity)Session["Sec"];
            // If the object is null, then it needs initializing
            if (Sec == null)
            {
                // Initialize the object
                Sec = new clsSecurity();
                // Update the session
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

            if (IsPostBack == false)
            {
                //update the list box
                DisplayEvent();
            }

            // Set the state of the links based on the current state of authentication
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

        //display all Event
        void DisplayEvent()
        {
            //create an instance of the clsEventBookingCollection
            clsEventBookingCollection Event = new clsEventBookingCollection();
            //set the data source to the list of Event in the collection
            idEventList.DataSource = Event.EventList;
            //set the name of the primary key
            idEventList.DataValueField = "BookingNo";
            //set the data field to display
            idEventList.DataTextField = "EventName";
            //bind the data to the list
            idEventList.DataBind();
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

        protected void btnEventSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            //var to store the primary key value of the record to be edited
            Int32 BookingNo;
            //if a record has been selected from the list
            if (idEventList.SelectedIndex != -1)
            {
                //get the primary key value of the record to edit
                BookingNo = Convert.ToInt32(idEventList.SelectedValue);
                //store the data in the session object
                Session["BookingNo"] = BookingNo;
                //redirect to the edit page
                Response.Redirect("EventBookingUpdateForm.aspx");
            }
            else //if no record has been selected
            {
                //display an error
                lblError.Text = "Please select a record to edit from the list";
            }
        }
    }
}