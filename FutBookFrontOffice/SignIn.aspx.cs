using FutBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FutBookFrontOffice
{
    public partial class SignIn : System.Web.UI.Page
    {

        //create a copy of the security object with page level scope
        clsSecurity Sec;

        protected void Page_Load(object sender, EventArgs e)
        {
            //get the current security state from the session
            Sec = (clsSecurity)Session["Sec"];

            //initialize the security object if it doesn't exist
            if (Sec == null)
            {
                Sec = new clsSecurity();
            }
        }
    

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //update the security state in the session
            Session["Sec"] = Sec;
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            //try to sign in and record any errors
            string Error = Sec.SignIn(idEmail.Text, idPassword.Text);
            //if there were no errors
            if (Error == "")
            {
                //redirect to the main page
                Response.Redirect("Default_aut.aspx");
            }
            else
            {
                //otherwise display any errors
                lblError.Text = Error;
            }
        }
    }
}