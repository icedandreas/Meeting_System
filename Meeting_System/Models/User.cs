using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_System.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstMiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime SignupDate { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
}
}