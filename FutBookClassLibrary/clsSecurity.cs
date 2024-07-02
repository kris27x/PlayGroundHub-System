using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// basic security class - free to use so long as you credit the author i.e. me
/// Matthew Dean mjdean@dmu.ac.uk
/// last update 17/8/2018
/// </summary>

namespace FutBookClassLibrary
{
    public class clsSecurity
    {
        public class clsEmail
        {
            ///this class is internal to clsSecurity just to make it simpler to use
            ///you may want to consider using this definition to create your own class
            ///within your class library and then get rid of this definition
            public string Subject { get; internal set; }
            public string Recipient { get; internal set; }
            public string Sender { get; internal set; }
            public string Body { get; internal set; }

            public void SendEmail()
            {
                //sends an Email
                //this function won't work till all the code is activated
                System.Net.Mail.MailMessage Email = new System.Net.Mail.MailMessage();
                System.Net.Mail.SmtpClient Server = new System.Net.Mail.SmtpClient("mail.dmu.ac.uk");
                Email = new System.Net.Mail.MailMessage(this.Sender, this.Recipient, this.Subject, this.Body);
                //Server.Send(Email);
            }

        }

        //private data members
        //used to store the Email address of the currently authenticated user
        private string mUserEmail = "";
        //indicates if the user is admin or not
        private Boolean mIsAdmin = false;
        //records the number of failed login attempts
        private Int32 mAttempts;
        //stores the most recently sent Email message by the security system
        private clsEmail mEmailMessage;
        //stores the user first name
        private string mFirstName;
        //stores the user surname
        private string mSurname;
        //stores the user phoneNo
        private Int64 mPhoneNo;
        //stores the user houseNo
        private int mHouseNo;
        //stores the user street
        private string mStreet;
        //stores the user city
        private string mCity;
        //stores the user postcode
        private string mPostCode;

        //constructor
        public clsSecurity()
        {
            //set attempts to zero
            mAttempts = 0;
        }


        public string SignUp(string Email, string Password, string ConfirmPassword, Boolean IsAdmin, string FirstName, string Surname, Int64 PhoneNo, int HouseNo, string Street, string City, string PostCode)
        //public method allowing the user to sign up for an account
        {
            //var to store any errors
            string Message = "";
                        
            //if the Email address isn't taken
            if (EmailTaken(Email) == false)
            {
                //if the two passwords match
                if (Password == ConfirmPassword)
                {
                    //check pasword complexity
                    Message = CheckPassword(Password);
                    //if complexity OK
                    if (Message == "")
                    {
                        //if the Email is valid
                        if (IsValidEmail(Email))
                        {
                            //get the hash of the plain text password
                            string HashPassword = GetHashString(Password + Email);
                            //add the record to the database
                            clsDataConnection DB = new clsDataConnection();
                            DB.AddParameter("@AccountEmail", Email.ToLower());
                            DB.AddParameter("@AccountPassword", HashPassword);
                            DB.AddParameter("@IsAdmin", IsAdmin);
                            DB.AddParameter("@FirstName", FirstName);
                            DB.AddParameter("@SurName", Surname);
                            DB.AddParameter("@PhoneNo", PhoneNo);
                            DB.AddParameter("@HouseNo", HouseNo);
                            DB.AddParameter("@Street", Street);
                            DB.AddParameter("@City", City);
                            DB.AddParameter("@PostCode", PostCode);
                            DB.Execute("sproc_tblAccount_Add");
                            //if active not set to true then request Email activation
                            if (IsAdmin == false)
                            {
                                //set the return message
                                Message = "The account has been created.";
                            }
                            else
                            {
                                
                            }
                        }
                        else
                        {
                            //set the return message
                            Message = "The e-mail address is not in a valid format";
                        }
                    }
                }
                //if the passwords do not match
                else
                {
                    //generate an error message
                    Message = "The passwords do not match.";
                }
            }
            else
            {
                //generate an error message
                Message = "The account already exists.";
            }
            //return the error message (if there is one)
            return Message;
        }

        private Boolean EmailTaken(string Email)
        {
            //tests to see if the Email address is taken
            //connect to the database and see if it there already
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@AccountEmail", Email.ToLower());
            DB.Execute("sproc_tblAccount_FilterByEmail");
            //if one record found then it is already gone
            if (DB.Count == 1)
            {
                //return true
                return true;
            }
            else
            {
                //return false
                return false;
            }
        }

        private string GetHashString(string SomeText)
        {
            //generates a hash for storing secure data in the database
            if (SomeText != "")//if there is text to process
            {
                //create an instance of the hash generator
                SHA256Managed HashGenerator = new SHA256Managed();
                //var to store the final hash
                string HashString;
                //array to store the bytes of the orignal text
                byte[] TextBytes;
                //array to store the bytes of the new hash
                byte[] HashBytes;
                //convert the text in the string to an array of bytes
                TextBytes = System.Text.Encoding.UTF8.GetBytes(SomeText);
                //generate the hash based on the array of bytes
                HashBytes = HashGenerator.ComputeHash(TextBytes);
                //generate the hash string replacing blank characters with -
                HashString = BitConverter.ToString(HashBytes).Replace("-", "");
                return HashString;
            }
            else        //if there is nothing to process
            {
                //return a blank string
                return "";
            }
        }

        public string SignIn(string Email, string Password)
        {
            //signs in a user based on their Email and password
            //ver to store any error messages
            string Error = "";
            //if not all attempts are used up
            if (mAttempts < 3)
            {
                //convert the plain text password to a hash code
                Password = GetHashString(Password + Email);
                //find the record matching the users Email address and password
                clsDataConnection User = new clsDataConnection();
                //add the parameters
                User.AddParameter("@AccountEmail", Email);
                User.AddParameter("@AccountPassword", Password);
                //execute the query
                User.Execute("sproc_tblAccount_FilterByEmailAndPassword");
                //If there is only one record found then return true
                if (User.Count >= 1)
                {
                    //get the state of admin
                    mIsAdmin = Convert.ToBoolean(User.DataTable.Rows[0]["IsAdmin"]);
                    //store the users Email address in the data member
                    mUserEmail = Email;

                    // Get the AccountNo from the record
                    int accountNo = Convert.ToInt32(User.DataTable.Rows[0]["AccountNo"]);
                    // Store the AccountNo in the session
                    HttpContext.Current.Session["AccountNo"] = accountNo;
                }
                else //otherwise return false
                {
                    //increment the number of failed attempts
                    mAttempts++;
                    //return a message
                    Error = "Sign-in failed";
                }
            }
            else
            {
                //return a message
                Error = "There have been too many failed attempts please exit the application.";
            }

            

            //return any error messages
            return Error;
        }

        private Boolean SignInWithTempPW(string Email, string TempPW)
        {
            //used to log an account in using a temporary password

            //find the record matching the users Email address and password
            clsDataConnection UserAccount = new clsDataConnection();
            //add the parameters
            UserAccount.AddParameter("@Email", Email);
            UserAccount.AddParameter("@TempPW", TempPW);
            //execute the query
            UserAccount.Execute("sproc_tblAccount_FilterByEmailAndTempPW");
            //If there is only one record found then return true
            if (UserAccount.Count >= 1)
            {
                //set the users Email address
                mUserEmail = Email;
                //return true to indicate login ok
                return true;
            }
            else //otherwise return false
            {
                return false;
            }
        }
        public string UserEmail
        //allows access to Email address of the current user
        {
            get
            {
                //return the Email address
                return mUserEmail;
            }
        }

        public clsEmail EmailMessage
        //allows access to the last sent Email message
        {
            get
            {
                //retunr the message
                return mEmailMessage;
            }
        }

        public bool Authenticated
        //indicates if the current user is authenticated
        {
            get
            {
                //if there is a valid Email address
                if (mUserEmail != "")
                {
                    //return true
                    return true;
                }
                else
                {
                    //return false
                    return false;
                }
            }
        }


        private string CheckPassword(string Password)
        //used to check that the password meets requirments
        {
            string Err = "";
            //if the password is less then 7 characters
            if (Password.Length < 7)
            {
                Err = "Your password must be at least 7 characters ";
            }
            //if the password doesn't contain a number
            if (ContainsNumber(Password) == false)
            {
                Err = Err + "your password must contain a number ";
            }
            //return any errors
            return Err;
        }

        private bool IsValidEmail(string Email)
        {
            //tests to see if an Email is in a valid format
            try
            {
                //try to assign the eail to an instance of System.Net.Mail.MailAddress
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(Email);
                //if all ok return true
                return true;
            }
            catch
            {
                //else return false
                return false;
            }
        }

        private Boolean ContainsNumber(string Password)
        {
            //checks to see if a password contains a number
            //var to indicate found
            Boolean Found = false;
            //counter for loop
            int Counter = 0;
            //used to store a single character
            char AChar;
            //while found is false and char less than 9
            while (Found == false & Counter < 9)
            {
                //set temp to the value of Counter plus 48 to point at the numeric ascii codes
                int Temp = Counter + 48;
                //get the char value of the ascii code
                AChar = (char)Temp;
                //if the code is in the password
                if (Password.Contains(AChar) == true)
                {
                    //set found = true
                    Found = true;
                }
                else
                {
                    //otherwise keep looking
                    Counter += 1;
                }
            }
            //return the state of found
            return Found;
        }

        public string ChangePasswordWithTempPW(string Email, string TempPW, string Password, string ConfirmPassword)
        {
            //used to change a password using a temporary system generated password

            //var to store any errors
            string Message = "";
            //if the pw is blank then stop the process
            if (TempPW != "")
            {
                //if the account logs in OK
                if (SignInWithTempPW(Email, TempPW) == true)
                {
                    //if the two passwords match
                    if (Password == ConfirmPassword)
                    {
                        //check pasword complexity
                        Message = CheckPassword(Password);
                        //if complexity OK
                        if (Message == "")
                        {
                            //get the hash of the plain text password
                            string HashPassword = GetHashString(Password + Email);
                            //update the users passwod
                            clsDataConnection DB = new clsDataConnection();
                            DB.AddParameter("@Email", Email.ToLower());
                            DB.AddParameter("@Password", HashPassword);
                            DB.Execute("sproc_tblUser_UpdatePassword");
                            //return a message
                            Message = "The password has been changed";
                        }
                    }
                    //if the passwords do not match
                    else
                    {
                        //generate an error message
                        Message = "The passwords do not match.";
                    }
                }
                else
                {
                    //generate an error message
                    Message = "String not valid.";
                }
            }
            else
            {
                //generate an error message
                Message = "String not valid.";
            }
            //return the error message (if there is one)
            return Message;
        }

        private string GetTempPW()
        {
            //generates a temporary system generated password
            //var to store the password
            string TempPW = "";
            //create a new object for random numbers
            Random rnd = new Random();
            //loop 40 times 
            for (Int32 Count = 0; Count < 40; Count++)
            {
                //generate a random number between 0 and 9
                string ANo = rnd.Next(9).ToString();
                //concatenate the number to the TempPW string
                TempPW = TempPW + ANo;
            }
            //return the string
            return TempPW;
        }
        public string ChangePassword(string Email, string CurrentPassword, string Password, string ConfirmPassword)
        {
            //used to change a users password
            //var to store any errors
            string Message = "";
            //if the account logs in OK 
            if (SignIn(Email, CurrentPassword) == "" | mIsAdmin == true)
            {
                //if the two passwords match
                if (Password == ConfirmPassword)
                {
                    //check pasword complexity
                    Message = CheckPassword(Password);
                    if (Message == "")
                    {
                        //get the hash of the plain text password
                        string HashPassword = GetHashString(Password + Email);
                        //updat the password
                        clsDataConnection DB = new clsDataConnection();
                        DB.AddParameter("@Email", Email.ToLower());
                        DB.AddParameter("@Password", HashPassword);
                        DB.Execute("sproc_tblUser_UpdatePassword");
                        Message = "The password has been changed.";
                    }
                }
                //if the passwords do not match
                else
                {
                    //generate an error message
                    Message = "The passwords do not match.";
                }
            }
            else
            {
                //generate an error message
                Message = "The existing password was not correct.";
            }
            //return the error message (if there is one)
            return Message;
        }

        //private void SendActivationEmail(string Email)
        //{
        //    //sends an activation Email to the user when Email confirmation is required
        //    //generate a new Email message
        //    mEmailMessage = new clsEmail();
        //    //set the subject
        //    mEmailMessage.Subject = "Instructions for activating your account";
        //    //set the recipient
        //    mEmailMessage.Recipient = Email;
        //    //set the sender
        //    mEmailMessage.Sender = "noreply@dmu.ac.uk";
        //    //generate a temporary system password
        //    string TempPW = GetTempPW();
        //    //set the body of the Email
        //    mEmailMessage.Body = "<a href=ActivateAccount.aspx?Email=" + Email + "&TempPW=" + TempPW + ">Activate Account</a>";
        //    //connect to the database
        //    clsDataConnection DB = new clsDataConnection();
        //    DB.AddParameter("@Email", Email.ToLower());
        //    DB.AddParameter("@TempPW", TempPW);
        //    //update the temporary password
        //    DB.Execute("sproc_tblAccount_UpdateTempPW");
        //    //send the Email
        //    mEmailMessage.SendEmail();
        //}

        public void SignOut()
        {
            //signs the user out of the system
            //set Email to a blank string
            mUserEmail = "";
            //set admin to false
            mIsAdmin = false;
        }

        public string ReSet(string Email)
        {
            //used to generate a re-set password Email message
            //string to store any message
            String Message = "";
            //if the Email exists
            if (EmailTaken(Email) == true)
            {
                //generate a new Email message
                mEmailMessage = new clsEmail();
                mEmailMessage.Subject = "Instructions for re-setting your password";
                mEmailMessage.Recipient = Email;
                mEmailMessage.Sender = "noreply@dmu.ac.uk";
                //get the temp password
                string TempPW = GetTempPW();
                mEmailMessage.Body = "<a href=ChangePassword.aspx?Email=" + Email + "&TempPW=" + TempPW + ">Re Set Password</a>";
                //updat the temp password in the database
                clsDataConnection DB = new clsDataConnection();
                DB.AddParameter("@Email", Email.ToLower());
                DB.AddParameter("@TempPW", TempPW);
                DB.Execute("sproc_tblAccount_UpdateTempPW");
                //send the Email
                mEmailMessage.SendEmail();
                //set the return message
                Message = "An Email has been sent to your acccount with instructions on how to re-set your password.";
            }
            else
            {
                //send error
                Message = "Account not found";
            }
            //return any messages
            return Message;
        }

        public Boolean IsAdmin
        {
            //used to flag if the user is admin or not
            get
            {
                //return state of data member
                return mIsAdmin;
            }
        }

        public string FirstName
        {
            get
            {
                return mFirstName;
            }
        }

        public string Surname
        {
            get
            {
                return mSurname;
            }
        }

        public Int64 PhoneNo
        {
            get
            {
                return mPhoneNo;
            }
        }

        public int HouseNo
        {
            get
            {
                return mHouseNo;
            }
        }

        public string Street
        {
            get
            {
                return mStreet;
            }
        }

        public string City
        {
            get
            {
                return mCity;
            }
        }

        public string PostCode
        {
            get
            {
                return mPostCode;
            }
        }

        public string ActivateAccount(string Email, string TempPW)
        {
            //used to activate a web generated account to verify the Email address
            //var to store any errors
            string Message = "";
            //if there is a temp pasword
            if (TempPW != "")
            {
                //if it is possible to login using temp pw
                if (SignInWithTempPW(Email, TempPW) == true)
                {
                    if (Message == "")
                    {
                        //Activate the account
                        clsDataConnection DB = new clsDataConnection();
                        DB.AddParameter("@Email", Email.ToLower());
                        DB.Execute("sproc_tblAccount_Activate");
                        Message = "The account has been activated";
                    }
                }
                else
                {
                    //generate an error
                    Message = "The was a problem activating the account";
                }
            }
            else
            {
                //generate an error
                Message = "Invalid string";
            }
            //return the error message (if there is one)
            return Message;
        }

        public string GetFirstNameByAccountNo(int accountNo)
        {
            // Create a new instance of clsDataConnection
            clsDataConnection DB = new clsDataConnection();

            // Add the @AccountNo parameter
            DB.AddParameter("@AccountNo", accountNo);

            // Execute the stored procedure
            DB.Execute("sproc_tblAccount_GetFirstNameByAccountNo");

            // Check if there is at least one row in the result
            if (DB.Count > 0)
            {
                // Get the first name from the first row
                string firstName = Convert.ToString(DB.DataTable.Rows[0]["FirstName"]);

                // Return the first name
                return firstName;
            }
            else
            {
                // Return an empty string if no rows were returned
                return string.Empty;
            }
        }
    }
}
