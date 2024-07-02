using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class ShopUpdateForm : System.Web.UI.Page
    {
        //variable to store the primary key with page level scope
        Int32 StockNo;

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
            //get the number of the stock to be processed
            StockNo = Convert.ToInt32(Session["StockNo"]);
            if (IsPostBack == false)
            {
                //if this is not a new record
                if (StockNo != -1)
                {
                    //display the current data for the record
                    DisplayStock();
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

        protected void btnUpdateStock_Click(object sender, EventArgs e)
        {
            //update stock
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
            //create an instance of the clsStockCollection
            clsStockCollection AStock = new clsStockCollection();
            //validate the data on the web form
            String Error = AStock.ThisStock.Valid(idStockName.Text, idStockPrice.Text, idStockQuantity.Text, idStockCategory.Text, idStockImage.FileBytes);
            //if the data is OK then add it to the object
            if (Error == "")
            {
                //find the record to update
                AStock.ThisStock.Find(StockNo);
                //get the data entered by the user
                AStock.ThisStock.StockName = idStockName.Text;                
                AStock.ThisStock.StockPrice = Convert.ToDecimal(idStockPrice.Text);
                AStock.ThisStock.StockQuantity = Convert.ToInt32(idStockQuantity.Text);
                AStock.ThisStock.StockCategory = idStockCategory.Text;
                AStock.ThisStock.StockImage = idStockImage.FileBytes;
                //update the record
                AStock.Update();
                //display success message
                lblError.Text = "Stock has been updated successfully.";
            }
            else
            {
                //report an error
                lblError.Text = "There were problems with the data entered " + Error;
            }
        }

        //display stock
        void DisplayStock()
        {
            //create an instance of the clsStockCollection
            clsStockCollection AStock = new clsStockCollection();
            //find the record to update
            AStock.ThisStock.Find(StockNo);
            //display the data for this record
            idStockName.Text = AStock.ThisStock.StockName;
            idStockCategory.Text = AStock.ThisStock.StockCategory;
            idStockPrice.Text = AStock.ThisStock.StockPrice.ToString();
            idStockQuantity.Text = AStock.ThisStock.StockQuantity.ToString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect to previous page
            Response.Redirect("ShopUpdate.aspx");
        }
    }
}