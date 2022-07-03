using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITTicketSystem.Data.AppUsers
{
    public class AppUser
    {
        public int AppUserID { get; set; }
        public string FirstName { get; set; }
        public string Status { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }        

        public DateTime UpdatedDate { get; set; }

        public double TotalCount { get; set; }
    }
}
