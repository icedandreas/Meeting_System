using Meeting_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Meeting_System.DAL
{
    public class SystemInitializer : System.Data.Entity.DropCreateDatabaseAlways<SystemContext>
    {
        public override void InitializeDatabase(SystemContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }
        protected override void Seed(SystemContext context)
        {
            /* Users - Meetings are many to many
             * Meetings - Rooms are one to many
             * Because of this I had to make individual variable names instead of a list
             */
            var user1 = new User { FirstMiddleName = "Andreas Laugård", LastName = "Hald", SignupDate = DateTime.Parse("01-10-2020")};
            var user2 = new User { FirstMiddleName = "Karl Børge", LastName = "Sigurdsen", SignupDate = DateTime.Parse("10-5-2020") };
            var user3 = new User { FirstMiddleName = "Kim", LastName = "Larsen", SignupDate = DateTime.Parse("02-04-2020") };
            var user4 = new User { FirstMiddleName = "Britney", LastName = "Spears", SignupDate = DateTime.Parse("02-04-2021") };
            var user5 = new User { FirstMiddleName = "Barack", LastName = "Obama", SignupDate = DateTime.Parse("24-12-2019") };
            var user6 = new User { FirstMiddleName = "Lars", LastName = "Von Trier", SignupDate = DateTime.Parse("26-08-2018") };
            var user7 = new User { FirstMiddleName = "Mette", LastName = "Frederiksen", SignupDate = DateTime.Parse("04-02-2020") };
            var user8 = new User { FirstMiddleName = "King", LastName = "Kong", SignupDate = DateTime.Parse("09-06-2020") };
            var user9 = new User { FirstMiddleName = "James", LastName = "Bond", SignupDate = DateTime.Parse("02-04-2020") };
            var user10 = new User { FirstMiddleName = "Michael", LastName = "Jackson", SignupDate = DateTime.Parse("05-07-1999") };

            var room1 = new Room { MaxCapacity = 5, Latitude = 0.0, Longtitude = 0.0 };
            var room2 = new Room { MaxCapacity = 10, Latitude = 100.0, Longtitude = 100.0 };

            var meeting1 = new Meeting { Title = "Budget meeting", Description = "A meeting to dicuss the budget for the next month", MeetingStart = DateTime.Parse("28-04-2021 13:45:00"), MeetingDuration = TimeSpan.Parse("01:00:00")};
            var meeting2 = new Meeting { Title = "Meetings meeting", Description = "This meeting is about discussing that we have too many meetings", MeetingStart = DateTime.Parse("30-04-2021 09:15:00"), MeetingDuration = TimeSpan.Parse("08:00:00") };
            var meeting3 = new Meeting { Title = "Monday meeting", Description = "This is the weekly mandatory early Monday meeting", MeetingStart = DateTime.Parse("03-05-2021 05:00:00"), MeetingDuration = TimeSpan.Parse("00:00:05") };

            meeting1.Users.Add(user1);
            user1.Meetings.Add(meeting1);
            meeting1.Users.Add(user2);
            user2.Meetings.Add(meeting1);
            meeting1.Users.Add(user3);
            user3.Meetings.Add(meeting1);
            meeting1.Users.Add(user4);
            user4.Meetings.Add(meeting1);
            meeting1.Users.Add(user5);
            user5.Meetings.Add(meeting1);
            meeting1.Users.Add(user6);
            user6.Meetings.Add(meeting1);
            meeting1.Users.Add(user7);
            user7.Meetings.Add(meeting1);
            meeting2.Users.Add(user8);
            user8.Meetings.Add(meeting1);
            meeting2.Users.Add(user9);
            user9.Meetings.Add(meeting1);
            meeting2.Users.Add(user10);
            user10.Meetings.Add(meeting1);
            meeting2.Users.Add(user1);
            user1.Meetings.Add(meeting2);
            meeting2.Users.Add(user2);
            user2.Meetings.Add(meeting2);
            meeting2.Users.Add(user3);
            user3.Meetings.Add(meeting2);
            meeting3.Users.Add(user4);
            user4.Meetings.Add(meeting3);
            meeting3.Users.Add(user5);
            user5.Meetings.Add(meeting3);

            room1.Meetings.Add(meeting1);
            room2.Meetings.Add(meeting2);
            room1.Meetings.Add(meeting3);

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Users.Add(user5);
            context.Users.Add(user6);
            context.Users.Add(user7);
            context.Users.Add(user8);
            context.Users.Add(user9);
            context.Users.Add(user10);
            context.Rooms.Add(room1);
            context.Rooms.Add(room2);
            context.Meetings.Add(meeting1);
            context.Meetings.Add(meeting2);
            context.Meetings.Add(meeting3);
            context.SaveChanges();
        }
    }
}