using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime MeetingStart { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan MeetingDuration { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
    }
}