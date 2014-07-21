using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Rusty.ObservationLog.Db;

namespace Rusty.ObservationLog.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var observation = FormController.ObservationForm;
            observation.Visible = false;

            MigrateToLatest();
            TouchDb();

            // Show the system tray icon.
            using (var pi = new ProcessIcon())
            {
                pi.Display();
                // Make sure the application runs!
                Application.Run();
                
            }
        }

        // ugly method to touch the db so that the first db connection happens at startup and not the first time a user tries to log an observation
        private static void TouchDb()
        {
            using (var db = new ObservationContext())
            {
                var user = db.Users.FirstOrDefault();
            }
        }

        private static void MigrateToLatest()
        {
            new DatabaseMigrator().MigrateToLatest();
        }
    }

    public class DatabaseMigrator
    {
        public void MigrateToLatest()
        {
            var migrateDatabaseToLatestVersion = new MigrateDatabaseToLatestVersion<ObservationContext, Db.Migrations.ObservationContextConfiguration>();
            Database.SetInitializer(migrateDatabaseToLatestVersion);
        }
    }
}
