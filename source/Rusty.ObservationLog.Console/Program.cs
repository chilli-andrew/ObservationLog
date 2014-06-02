using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Rusty.ObservationLog.Db;
using Rusty.ObservationLog.Domain;

namespace Rusty.ObservationLog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Started");
            using (var db = new ObservationContext())
            {
                var windowsLogon = WindowsIdentity.GetCurrent().Name;
                //            var newUser = new User { UserName = windowsLogon, WindowsLogon = windowsLogon };
                //            db.Users.Add(newUser);
                //            db.SaveChanges();
                //            var users = db.Users;
                //            foreach (var user in users)
                //            {
                //                System.Console.WriteLine("User Name: {0}, Windows Logon: {1}", user.UserName, user.WindowsLogon);
                //            }



                var currentUser = GetCurrentUser(db, windowsLogon);
                if (CurrentUserNotFound(currentUser))
                {
                    CreateCurrentUser(windowsLogon, db);
                    currentUser = GetCurrentUser(db, windowsLogon);
                }

                var observation = new Observation
                {
                    ObservationDate = DateTime.Now,
                    ObservationText = "my 1st recorded observation",
                    User = currentUser
                };

                db.Observations.Add(observation);
                db.SaveChanges();
            }
            System.Console.WriteLine("Done. Press any key");
            System.Console.ReadKey();
        }

        private static void CreateCurrentUser(string windowsLogon, ObservationContext db)
        {
            var newUser = new User {UserName = windowsLogon, WindowsLogon = windowsLogon};
            db.Users.Add(newUser);
        }

        private static bool CurrentUserNotFound(User currentUser)
        {
            return currentUser == null;
        }

        private static User GetCurrentUser(ObservationContext db, string windowsLogon)
        {
            return db.Users.FirstOrDefault(user => user.WindowsLogon==windowsLogon);
        }
    }
}
