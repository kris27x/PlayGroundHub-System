using System;

namespace FutBookClassLibrary
{
    public class clsOrderLine
    {
        public int OrderLineNo { get; set; }
        public double OrderTotalPrice { get; set; }
        public int OrderLineQuantity { get; set; }

        public Boolean Valid(string OrderLineQuantity)
        {
            //var to record any errors found in OrderLineQuantity 
            Boolean OK = true;
            //test to see if the OrderLineQuantity has zero characters
            if(OrderLineQuantity.Length == 0)
            {
                //set OK to false
                OK = false;
            }
            //test to see if the OrderLineQuantity is no more than 7 characters
            if (OrderLineQuantity.Length > 7)
            {
                //set OK to false
                OK = false;
            }
            //return the results of all tests
            return OK;
        }
    }
}