using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutBookClassLibrary
{
    public class clsBasket
    {

        /// this class defines some typical attributes of a shopping basket


        List<clsBasketItem> mProducts = new List<clsBasketItem>();
        public clsBasket()
        {

        }

        private Int32 mAccountNo;
        public Int32 AccountNo
        {
            get
            {
                return mAccountNo;
            }
            set
            {
                mAccountNo = value;
            }
        }
        public List<clsBasketItem> Products
        {
            get
            {
                return mProducts;
            }
        }

        public void Checkout()
        {
            //create an instance of the order class
            clsOrder Order = new clsOrder();
            //invoke the ProcessCart method
            Order.ProcessCart(this);
        }
    }
}
