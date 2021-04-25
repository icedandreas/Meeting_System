using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_System.Models
{
    public class User
    {
        public User()
        {
            this.Meetings = new List<Meeting>();
        }
        public int UserId { get; set; }
        public string FirstMiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime SignupDate { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
}
}