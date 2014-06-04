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
                var observations = db.Observations;
                foreach (var observation in observations)
                {
                    System.Console.WriteLine("{0}: {1} {2}", windowsLogon, observation.ObservationText, observation.ObservationDate.ToString("yyyy-MM-dd hh:mm:ss"));
                }
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
