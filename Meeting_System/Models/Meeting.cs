using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_System.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public int RoomID { get; set; }
        public DateTime MeetingStart { get; set; }
        public int MeetingDuration { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}