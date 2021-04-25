using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_System.Models
{
    public class Meeting
    {
        public Meeting()
        {
            this.Users = new HashSet<User>();
        }
        public int MeetingId { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public DateTime MeetingStart { get; set; }
        public TimeSpan MeetingDuration { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
        /*
        [ForeignKey("Room")]
        public int RoomRefId { get; set; }
        public Room Room { get; set; }
        */
    }
}