using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutBookClassLibrary
{
    public class clsBasketItem
    {
        public clsBasketItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private Int32 mStockNo;
        public Int32 StockNo
        {
            get
            {
                return mStockNo;
            }

            set
            {
                mStockNo = value;
            }
        }

        private Int32 mQTY;
        public Int32 QTY
        {
            get
            {
                return mQTY;
            }

            set
            {
                mQTY = value;
            }
        }

        private decimal mPrice;
        public decimal Price
        {
            get
            {
                return mPrice;
            }

            set
            {
                mPrice = value;
            }
        }

    }
}
