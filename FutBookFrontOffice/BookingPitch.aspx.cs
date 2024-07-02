using FutBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FutBookFrontOffice
{
    public partial class BookingPitch : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                // Add the today date and the next 7 days to the dropdown list
                for (int i = 0; i < 8; i++)
                {
                    ddlDate.Items.Add(DateTime.Today.AddDays(i).ToString("dd-MMMM"));
                }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.Parse(ddlDate.SelectedValue);
            TimeSpan selectedTime = TimeSpan.Parse(DropDownList1.SelectedValue);

            if (selectedDate == DateTime.Today && selectedTime < DateTime.Now.TimeOfDay)
            {
                lblError.Text = "You cannot select a time that has already passed today.";
                return;
            }

           try
            {
            clsBookingPitch booking = new clsBookingPitch();
            booking.BookingPitchDate = DateTime.Parse(ddlDate.SelectedValue);
            booking.BookingPitchTime = TimeSpan.Parse(DropDownList1.SelectedValue);
            booking.AccountNo = (int)Session["AccountNo"];
            booking.AddBooking();
            lblMessage.Text = "Booking has been made successfully!";
            lblMessage.Visible = true;

            }


            catch (SqlException ex)
            {
                if (ex.Number == 50000)
                {
                    lblError.Text = ex.Message;
                }
                else
                {
                    lblError.Text = "All pitches are already booked for the selected date and time";
                }
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Nothing
        }

    }
}
