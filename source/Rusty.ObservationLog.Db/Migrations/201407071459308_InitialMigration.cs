namespace Rusty.ObservationLog.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            // do nothing as these tables already exist
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Observations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tags", "Observation_Id", "dbo.Observations");
            DropIndex("dbo.Tags", new[] { "Observation_Id" });
            DropIndex("dbo.Observations", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.Observations");
        }
    }
}
