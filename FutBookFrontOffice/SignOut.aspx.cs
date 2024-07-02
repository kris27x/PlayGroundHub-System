using FutBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FutBookFrontOffice
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //create a new instance of the security object
            clsSecurity Sec;
            //get the data from the session
            Sec = (clsSecurity)Session["Sec"];
            //invoke the sign-out method
            Sec.SignOut();
            //update the copy in the session
            Session["Sec"] = Sec;
            //re-direct to the main page
            Response.Redirect("Default_aut.aspx");
        }
    }
}