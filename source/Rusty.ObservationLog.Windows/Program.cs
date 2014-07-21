using System;
using System.Data.Entity;
using System.Windows.Forms;
using Rusty.ObservationLog.Db;
using Rusty.ObservationLog.Domain;

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

            // Show the system tray icon.
            using (var pi = new ProcessIcon())
            {
                pi.Display();

                // Make sure the application runs!
                Application.Run();
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
