using System;

namespace FutBookClassLibrary
{
    public class clsStock
    {
        //StockNo private member variable
        private Int32 mStockNo;
        //StockNo public property
        public Int32 StockNo
        {
            get
            {
                //this line of code sends data out of the property
                return mStockNo;
            }
            set
            {
                //this line of code allows data into the property
                mStockNo = value;
            }
        }

        //StockName private member variable
        private string mStockName;
        //StockName public property
        public string StockName
        {
            get
            {
                //this line of code sends data out of the property
                return mStockName;
            }
            set
            {
                //this line of code allows data into the property
                mStockName = value;
            }
        }
        //StockQuantity private member variable
        private Int32 mStockQuantity;
        //StockQuantity public property
        public Int32 StockQuantity
        {
            get
            {
                //this line of code sends data out of the property
                return mStockQuantity;
            }
            set
            {
                //this line of code allows data into the property
                mStockQuantity = value;
            }
        }

        //StockPrice private member variable
        private decimal mStockPrice;
        //StockPrice public property
        public decimal StockPrice
        {
            get
            {
                //this line of code sends data out of the property
                return mStockPrice;
            }
            set
            {
                //this line of code allows data into the property
                mStockPrice = value;
            }
        }
        //StockCategory private member variable
        private string mStockCategory;
        //StockCategory public property
        public string StockCategory
        {
            get
            {
                //this line of code sends data out of the property
                return mStockCategory;
            }
            set
            {
                //this line of code allows data into the property
                mStockCategory = value;
            }
        }

        //StockImage private member variable
        private byte[] mStockImage;
        //StockImage public property
        public byte[] StockImage
        {
            get
            {
                //this line of code sends data out of the property
                return mStockImage;
            }
            set
            {
                //this line of code allows data into the property
                mStockImage = value;
            }
        }

        public bool Find(int StockNo)
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the stock id to search for
            DB.AddParameter("@StockNo", StockNo);
            //execute the stored procedure
            DB.Execute("sproc_tblStock_FilterByStockNo");
            //if one record is found (there should be either one or zero)
            if (DB.Count == 1)
            {
                //copy the data from the database to the private data members
                mStockNo = Convert.ToInt32(DB.DataTable.Rows[0]["StockNo"]);
                mStockName = Convert.ToString(DB.DataTable.Rows[0]["StockName"]);
                mStockQuantity = Convert.ToInt32(DB.DataTable.Rows[0]["StockQuantity"]);
                mStockPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["StockPrice"]);
                mStockCategory = Convert.ToString(DB.DataTable.Rows[0]["StockCategory"]);
                mStockImage = (byte[])DB.DataTable.Rows[0]["StockImage"];
                //return that everything worked OK
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating problem
                return false;
            }
        }

        public string Valid(string stockName, string stockPrice, string stockQuantity, string stockCategory, byte[] stockImage)
        {
            //create a string variable to store the error
            String Error = "";
            //create variables for price and quantity
            decimal price;
            int quantity;

            //if the StockName is blank
            if (stockName.Length == 0)
            {
                //record the error
                Error = Error + "The stock name may not be blank : ";
            }
            //if the StockName is greater than 50 characters
            if (stockName.Length > 50)
            {
                //record the error
                Error = Error + "The stock name must be less than 50 characters : ";
            }            
            //if the StockQuantity is not a valid number
            if (!Int32.TryParse(stockQuantity, out quantity) || quantity <= 0)
            {
                //record the error
                Error = Error + "The stock quantity must be a valid number greater than zero : ";
            }
            //if the StockQuantity is greater than 9999
            if (quantity > 9999)
            {
                //record the error
                Error = Error + "The stock quantity must be less than 9999 : ";
            }
            //if the StockPrice is not a valid number
            if (!decimal.TryParse(stockPrice, out price) || price <= 0)
            {
                //record the error
                Error = Error + "The stock price must be a valid number greater than zero : ";
            }
            //if the StockPrice is greater than 99 999
            if (price > 99999)
            {
                //record the error
                Error = Error + "The stock price must be less than 100 000 : ";
            }
            //if the StockCategory is blank
            if (stockCategory.Length == 0)
            {
                //record the error
                Error = Error + "The stock type may not be blank : ";
            }
            //if the StockCategory is greater than 30 characters
            if (stockCategory.Length > 30)
            {
                //record the error
                Error = Error + "The stock type must be less than 50 characters : ";
            }
            //if the StockImage is null or empty
            if (stockImage == null || stockImage.Length == 0)
            {
                //record the error
                Error = Error + "The stock image may not be blank : ";
            }

            //return any error messages
            return Error;
        }
}
}