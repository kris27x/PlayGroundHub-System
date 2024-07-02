using FutBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FutBookFrontOffice
{
    public partial class ShopHome : System.Web.UI.Page
    {
        //create an instance of the security class with page level scope
        clsSecurity Sec;

        //find first name of the user
        private string GetFirstNameFromDatabase(int accountNo)
        {
            // Get the first name from the database using the AccountNo
            string firstName = Sec.GetFirstNameByAccountNo(accountNo);

            // Return the first name
            return firstName;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayStockItems();
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

            SetLinks(Sec.Authenticated, Sec.IsAdmin);

            //display user firstName
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

        private void DisplayStockItems()
        {
            clsStockCollection stockCollection = new clsStockCollection();
            stockCollection.FetchAll();

            HashSet<string> categories = new HashSet<string>();

            StringBuilder html = new StringBuilder();
            html.Append("<div class=\"row text-center product-category\" id=\"all-products\">");

            foreach (clsStock stockItem in stockCollection.StockList)
            {
                categories.Add(stockItem.StockCategory);

                html.Append($@"<div class=""col-sm-4"">
                    <div class=""thumbnail"">
                        <a href=""ShopDescription.aspx?stockNo={stockItem.StockNo}"" data-category=""{stockItem.StockCategory.ToLower()}"">
                            <img src=""data:image;base64,{Convert.ToBase64String(stockItem.StockImage)}"" alt=""{stockItem.StockName}"">
                        </a>
                        <div class=""stock-details"">
                            <a href=""ShopDescription.aspx?stockNo={stockItem.StockNo}"" data-category=""{stockItem.StockCategory.ToLower()}"">
                                <h5 style=""color: #ed3b3b; margin-top: 5px;""><strong>{stockItem.StockName}</strong></h5>
                            </a>
                            <p class=""stock-price"">Price: {stockItem.StockPrice}</p>
                       
                        </div>
                    </div>
                </div>");
            }
            html.Append("</div>");

            stockItemsContainer.InnerHtml = html.ToString();

            // Generate category links
            html.Clear();
            html.Append("<a href=\"#\" class=\"category-link\" data-category=\"all\">Show all</a>");
            foreach (string category in categories)
            {
                html.Append($"<a href=\"#\" class=\"category-link\" data-category=\"{category.ToLower()}\">{category}</a>");
            }
            categoryLinks.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}