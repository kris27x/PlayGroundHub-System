using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FutBookClassLibrary;

namespace FutBookFrontOffice
{
    public partial class ShopBasketRemove : System.Web.UI.Page
    {
        clsBasket MyBasket = new clsBasket();

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 Index;
            //upon loading the page you need to read in the cart from the session object
            MyBasket = (clsBasket)Session["MyBasket"];
            //get the index of the item to remove
            Index = Convert.ToInt32(Request.QueryString["Index"]);
            //remove the item in the query string
            MyBasket.Products.RemoveAt(Index);
            //go back to view cart
            Response.Redirect("ShopBasket.aspx");
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyBasket"] = MyBasket;
        }
    }
}