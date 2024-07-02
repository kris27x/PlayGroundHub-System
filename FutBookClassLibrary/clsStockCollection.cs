using System;
using System.Collections.Generic;
using System.Data;

namespace FutBookClassLibrary
{
    public class clsStockCollection
    {
        //private data member for the list
        List<clsStock> mStockList = new List<clsStock>();
        //private data member thisStock
        clsStock mThisStock = new clsStock();

        //constructor for the class
        public clsStockCollection()
        {
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblStock_SelectAll");
            //populate the array list with the data table
            PopulateArray(DB);
        }

        //public property for the stock list
        public List<clsStock> StockList
        {
            get
            {
                //return the private data
                return mStockList;
            }
            set
            {
                //set the private data
                mStockList = value;
            }
        }

        public int Count
        {
            get
            {
                //return the count of the list
                return mStockList.Count;
            }
            set
            {
                //
            }
        }
        public clsStock ThisStock
        {
            get
            {
                //return the private data
                return mThisStock;
            }
            set
            {
                //set the private data
                mThisStock = value;
            }
        }

        public int Add()
        {
            //adds a new record to the database based on the values of mThisStock
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@StockName", mThisStock.StockName);
            DB.AddParameter("@StockQuantity", mThisStock.StockQuantity);
            DB.AddParameter("@StockPrice", mThisStock.StockPrice);
            DB.AddParameter("@StockCategory", mThisStock.StockCategory);
            DB.AddParameter("@StockImage", mThisStock.StockImage);
            //execute the query returning the primary key value
            return DB.Execute("sproc_tblStockAdd");
        }

        public void Delete()
        {
            // deletes the record pointed to by thisStock
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@StockNo", mThisStock.StockNo);
            //execute the stored procedure
            DB.Execute("sproc_tblStock_Delete");
        }

        void PopulateArray(clsDataConnection DB)
        {
            //populates the array list based on the data table in the parameter DB
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount;
            //get the count of records
            RecordCount = DB.Count;
            //clear the private array list
            mStockList = new List<clsStock>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsStock MyStock = new clsStock();
                //read in the fields from the current record
                MyStock.StockNo = Convert.ToInt32(DB.DataTable.Rows[Index]["StockNo"]);
                MyStock.StockName = Convert.ToString(DB.DataTable.Rows[Index]["StockName"]);
                MyStock.StockQuantity = Convert.ToInt32(DB.DataTable.Rows[Index]["StockQuantity"]);
                MyStock.StockPrice = Convert.ToInt32(DB.DataTable.Rows[Index]["StockPrice"]);
                MyStock.StockCategory = Convert.ToString(DB.DataTable.Rows[Index]["StockCategory"]);
                //add the record to the private data member
                mStockList.Add(MyStock);
                //point at the next record
                Index++;
            }
        }

        public void Update()
        {
            //update an existing record based on the values of ThisStock
            //connect to database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@StockNo", mThisStock.StockNo);
            DB.AddParameter("@StockName", mThisStock.StockName);
            DB.AddParameter("@StockPrice", mThisStock.StockPrice);
            DB.AddParameter("@StockQuantity", mThisStock.StockQuantity);            
            DB.AddParameter("@StockCategory", mThisStock.StockCategory);
            DB.AddParameter("@StockImage", mThisStock.StockImage);
            //execute the stored procedure
            DB.Execute("sproc_tblStockUpdate");
        }

        public void FetchAll()
        {
            // Clear the current StockList
            StockList.Clear();

            // Create an instance of clsDataConnection
            clsDataConnection DB = new clsDataConnection();

            // Execute the query and read the results
            DB.Execute("sproc_tblStock_SelectAll");

            // Loop through the rows of the DataTable and create clsStock objects
            foreach (DataRow row in DB.DataTable.Rows)
            {
                clsStock stockItem = new clsStock();
                stockItem.StockNo = Convert.ToInt32(row["StockNo"]);
                stockItem.StockName = Convert.ToString(row["StockName"]);
                stockItem.StockPrice = Convert.ToDecimal(row["StockPrice"]);
                stockItem.StockQuantity = Convert.ToInt32(row["StockQuantity"]);
                stockItem.StockCategory = Convert.ToString(row["StockCategory"]);
                stockItem.StockImage = row.IsNull("StockImage") ? null : (byte[])row["StockImage"];

                StockList.Add(stockItem);
            }
        }

        public clsStock FindByStockNo(int stockNo)
        {
            // Create an instance of clsDataConnection
            clsDataConnection DB = new clsDataConnection();

            // Add the StockNo parameter
            DB.AddParameter("@StockNo", stockNo);

            // Execute the query and read the results
            DB.Execute("sproc_tblStock_FilterByStockNo");

            // Check if a row was returned
            if (DB.Count == 1)
            {
                // Create a new clsStock object
                clsStock stockItem = new clsStock();

                // Populate the object with data from the database
                stockItem.StockNo = Convert.ToInt32(DB.DataTable.Rows[0]["StockNo"]);
                stockItem.StockName = Convert.ToString(DB.DataTable.Rows[0]["StockName"]);
                stockItem.StockPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["StockPrice"]);
                stockItem.StockQuantity = Convert.ToInt32(DB.DataTable.Rows[0]["StockQuantity"]);
                stockItem.StockCategory = Convert.ToString(DB.DataTable.Rows[0]["StockCategory"]);
                stockItem.StockImage = DB.DataTable.Rows[0].IsNull("StockImage") ? null : (byte[])DB.DataTable.Rows[0]["StockImage"];

                // Return the stock item
                return stockItem;
            }
            else
            {
                // If no rows were returned, return null
                return null;
            }
        }

        public List<clsStock> GetStockBySearchTerm(string searchTerm)
        {
            // Create a new instance of clsDataConnection
            clsDataConnection DB = new clsDataConnection();

            // Add the StockName parameter
            DB.AddParameter("@StockName", searchTerm);

            // Execute the stored procedure
            DB.Execute("sproc_tblStock_FilterByStockName");

            // Populate the list with the data table
            PopulateArray(DB);

            // Return the list of stocks
            return mStockList;
        }
    }
}