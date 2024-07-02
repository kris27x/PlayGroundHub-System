using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutBookClassLibrary
{
    public class clsAccount
    {
        public int AccountNo { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public Boolean Valid(string firstName, string surName, string phoneNo)
        {
            //return true
            return true;
        }
    }
}
