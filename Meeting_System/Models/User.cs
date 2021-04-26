using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_System.Models
{
    public class User
    {
        public User()
        {
            this.Meetings = new HashSet<Meeting>();
        }
        public int UserId { get; set; }
        [Column("FirstName")]
        public string FirstMiddleName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SignupDate { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
        [DataType(DataType.EmailAddress)]
        public object EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        public object PhoneNumber { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMiddleName;
            }
        }
    }
}