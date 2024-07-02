using FutBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FutBookFrontOffice
{
    public partial class Registration : System.Web.UI.Page
    {

        //create a copy of the security object with page level scope
        clsSecurity Sec;
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
            SetLinks(Sec.Authenticated);
        }

        private void SetLinks(Boolean Authenticated)
        {
            ///sets the visiible state of the links based on the authentication state
            ///

            //set the state of the following to not authenticated i.e. they will be visible when not logged in
            hypSignUp.Visible = !Authenticated;
            hypSignIn.Visible = !Authenticated;
            //set the state of the following to authenticated i.e. they will be visible when user is logged in
            hypSignOut.Visible = Authenticated;
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //create a new instance of the security class
            clsSecurity Sec = new clsSecurity();

            //validate the input fields
            if (string.IsNullOrEmpty(idEmail.Text))
            {
                lblError.Text = "Please enter an email address.";
                return;
            }

            if (string.IsNullOrEmpty(idPassword1.Text) || string.IsNullOrEmpty(idPassword2.Text))
            {
                lblError.Text = "Please enter a password.";
                return;
            }

            if (idPassword1.Text != idPassword2.Text)
            {
                lblError.Text = "Passwords do not match.";
                return;
            }

            if (string.IsNullOrEmpty(idFirstName.Text) || string.IsNullOrEmpty(idSurname.Text))
            {
                lblError.Text = "Please enter your surname.";
                return;
            }

            if (string.IsNullOrEmpty(idPhoneNo.Text) || string.IsNullOrEmpty(idHouseNo.Text))
            {
                lblError.Text = "Please enter a valid phone number and house number.";
                return;
            }

            if (string.IsNullOrEmpty(idStreet.Text) || string.IsNullOrEmpty(idCity.Text) || string.IsNullOrEmpty(idPostCode.Text))
            {
                lblError.Text = "Please enter your full address.";
                return;
            }

            if (!IsValidEmail(idEmail.Text))
            {
                lblError.Text = "Please enter a valid email address.";
                return;
            }
            //try to sign up using the supplied credentials
            string Outcome = Sec.SignUp(idEmail.Text, idPassword1.Text, idPassword2.Text, false, idFirstName.Text, idSurname.Text, Convert.ToInt64(idPhoneNo.Text), Convert.ToInt32(idHouseNo.Text), idStreet.Text, idCity.Text, idPostCode.Text);
            //report the outcome of the operation
            lblError.Text = Outcome;
            //store the object in the session objec for other pages to access
            Session["Sec"] = Sec;
        }
        private bool IsValidEmail(string email)
        {
            // This method uses a regular expression to validate the email format
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            var emailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
            return emailRegex.IsMatch(email);
        }
    }
}