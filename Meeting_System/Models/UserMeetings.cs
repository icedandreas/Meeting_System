using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_System.Models
{
    public class UserMeeting
    {
        //I'm not sure I actually needs this file. Seems EF handled the creation of a many to many join on its own.
        public int UserId { get; set; }
        public User User { get; set; }
        public int MettingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}