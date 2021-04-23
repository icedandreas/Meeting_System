using Meeting_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Meeting_System.DAL
{
    public class SystemInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SystemContext>
    {
        protected override void Seed(SystemContext context)
        {
            var users = new List<User>
            {
                new User {FirstMiddleName="Andreas Laugård", LastName="Hald", SignupDate=DateTime.Parse("01-10-2020")},
                new User {FirstMiddleName="Karl Børge", LastName="Sigurdsen", SignupDate=DateTime.Parse("10-5-2020")},
                new User {FirstMiddleName="Kim", LastName="Larsen", SignupDate=DateTime.Parse("02-04-2020")},
                new User {FirstMiddleName="Britney", LastName="Spears", SignupDate=DateTime.Parse("02-04-2021")},
                new User {FirstMiddleName="Barrack", LastName="Obama", SignupDate=DateTime.Parse("24-12-2019")},
                new User {FirstMiddleName="Lars", LastName="Von Trier", SignupDate=DateTime.Parse("26-08-2018")},
                new User {FirstMiddleName="Mette", LastName="Frederiksen", SignupDate=DateTime.Parse("04-02-2020")},
                new User {FirstMiddleName="King", LastName="Kong", SignupDate=DateTime.Parse("09-06-2020")},
                new User {FirstMiddleName="James", LastName="Bond", SignupDate=DateTime.Parse("02-04-2020")},
                new User {FirstMiddleName="Michael", LastName="Jackson", SignupDate=DateTime.Parse("05-07-1999")}
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var meetings = new List<Meeting>
            {
                new Meeting {Title="Budget meeting", Description="A meeting to dicuss the budget for the next month", MeetingStart=DateTime.Parse("28-04-2021 13:45:00"), MeetingDuration=60, RoomID=1},
                new Meeting {Title="Meeting meeting", Description="This meeting is about discussing that we have too many meetings", MeetingStart=DateTime.Parse("30-04-2021 09:15:00"), MeetingDuration=480, RoomID=2},
                new Meeting {Title="Monday meeting", Description="This is the weekly mandatory early Monday meeting", MeetingStart=DateTime.Parse("03-05-2021 05:00:00"), MeetingDuration=5, RoomID=1}
            };
            meetings.ForEach(s => context.Meetings.Add(s));
            context.SaveChanges();

            var rooms = new List<Room>
            {
                new Room {MaxCapacity=5, ID=1, Latitude=0.0, Longtitude=0.0},
                new Room {MaxCapacity=10, ID=2, Latitude=100.0, Longtitude=100.0}
            };
            rooms.ForEach(s => context.Rooms.Add(s));
            context.SaveChanges();
        }
    }
}