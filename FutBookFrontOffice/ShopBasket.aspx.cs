using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class ShopBasket : System.Web.UI.Page
    {
        //create an instance of the security class with page level scope
        clsSecurity Sec;
        //create an instance of the basket class
        clsBasket MyBasket = new clsBasket();


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

            // If the user is not authenticated or not an admin, redirect to a default page
            if (!isAuthenticated)
            {
                Response.Redirect("Permission.aspx");
            }

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

            if (Session["MyBasket"] != null)
            {
                MyBasket = (clsBasket)Session["MyBasket"];
                RenderBasketItems();
            }
            else
            {
                MyBasket = new clsBasket();
                Session["MyBasket"] = MyBasket;
            }
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

        private void RenderBasketItems()
        {
            clsStockCollection stockCollection = new clsStockCollection();

            StringBuilder html = new StringBuilder();
            html.Append("<div class='d-flex justify-content-center'><table class='table table-striped text-white'><thead><tr><th>Image</th><th>Product</th><th>Quantity</th><th>Price</th><th>Remove</th></tr></thead><tbody>");

            int index = 0;
            decimal total = 0;

            foreach (clsBasketItem item in MyBasket.Products)
            {
                clsStock stockItem = stockCollection.FindByStockNo(item.StockNo);
                decimal price = stockItem.StockPrice * item.QTY;
                total += price;

                html.Append($@"<tr>
                    <td>
                        <img src=""data:image;base64,{Convert.ToBase64String(stockItem.StockImage)}"" style=""max-height: 50px;"" alt=""{stockItem.StockName}"" />
                    </td>
                    <td>{stockItem.StockName}</td>
                    <td>{item.QTY}</td>
                    <td>{price}</td>
                    <td>
                        <a href='ShopBasketRemove.aspx?Index={index}' class='text-white font-weight-bold'>Remove</a>
                    </td>
                    </tr>");

                index++;
            }

            html.Append("</tbody></table></div>");

            // Add the total price below the table
            html.Append($"<div class='text-white text-center mb-3'>Total Price: {total}</div>");

            cartItemsContainer.Attributes.Add("class", "w-100");


            Literal content = new Literal();
            content.Text = html.ToString();

            cartItemsContainer.Controls.Add(content);
        }



        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopCheckout.aspx");
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopHome.aspx");
        }
    }
}