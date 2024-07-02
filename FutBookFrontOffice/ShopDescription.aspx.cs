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
    public partial class ShopDescription : System.Web.UI.Page
    {
        //create an instance of the security class with page level scope
        clsSecurity Sec;

        clsBasket MyBasket = new clsBasket();
        Int32 StockNo;

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

            if (!IsPostBack)
            {
                if (Request.QueryString["stockNo"] != null)
                {
                    int stockNo = Convert.ToInt32(Request.QueryString["stockNo"]);
                    clsStock stockItem = GetStockItemByStockNo(stockNo);
                    RenderStockItem(stockItem);
                }
            }

            if (!IsPostBack)
            {
                // Populate the DropDownList with quantity options
                for (int i = 1; i <= 10; i++)
                {
                    ddlQuantity.Items.Add(i.ToString());
                }
            }

            if (Session["MyBasket"] != null)
            {
                MyBasket = (clsBasket)Session["MyBasket"];
            }
            else
            {
                MyBasket = new clsBasket();
                Session["MyBasket"] = MyBasket;
            }

            //you also need to get the product id from the query string
            StockNo = Convert.ToInt32(Request.QueryString["StockNo"]);
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the basket every time the unload event takes place
            Session["MyBasket"] = MyBasket;
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

        protected void btnAddToBasket_Click(object sender, EventArgs e)
        {
            //int selectedQuantity = int.Parse(ddlQuantity.SelectedValue);

            // Add the selected item and quantity to the basket
            //create a new instance of clsCartItem
            clsBasketItem AnItem = new clsBasketItem();
            //set the product id
            AnItem.StockNo = StockNo;
            //set the quantity
            AnItem.QTY = Convert.ToInt32(ddlQuantity.SelectedValue);
            //add the item to the basket's products collection
            MyBasket.Products.Add(AnItem);

            //redirect to the main page
            Response.Redirect("ShopBasket.aspx");
        }

        private clsStock GetStockItemByStockNo(int stockNo)
        {
            // Create an instance of the clsStockCollection class
            clsStockCollection stockCollection = new clsStockCollection();

            // Call the FindByStockNo method in the clsStockCollection class to fetch the stock item data using the stockNo
            clsStock stockItem = stockCollection.FindByStockNo(stockNo);

            // Return the fetched stock item
            return stockItem;
        }

        private void RenderStockItem(clsStock stockItem)
        {
            StringBuilder html = new StringBuilder();

            html.Append($@"<div class=""row"">
                    <div class=""col-5 mt-5"">
                        <img src=""data:image;base64,{Convert.ToBase64String(stockItem.StockImage)}"" style=""height: 260px;"" alt=""{stockItem.StockName}"" />
                    </div>
                    <div class=""col-7 mt-5"">
                        <h2>{stockItem.StockName}</h2>
                        <h5>Price: {stockItem.StockPrice}</h5>
                        <h5>Available quantity: {stockItem.StockQuantity}</h5>
                    </div>
                </div>");

            // Create a new Literal control to hold the HTML content
            Literal content = new Literal();
            content.Text = html.ToString();

            // Add the Literal control to the Panel
            stockItemContainer.Controls.Add(content);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect to the main page
            Response.Redirect("ShopHome.aspx");
        }
    }
}