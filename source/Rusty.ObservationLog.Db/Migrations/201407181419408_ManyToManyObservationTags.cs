namespace Rusty.ObservationLog.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyObservationTags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Observation_Id", "dbo.Observations");
            //DropForeignKey("dbo.ObservationTags", "ObservationId", "dbo.Observations");
            DropIndex("dbo.Tags", new[] { "Observation_Id" });
            DropPrimaryKey("dbo.Observations");
            CreateTable(
                "dbo.ObservationTags",
                c => new
                    {
                        ObservationTagsId = c.Int(nullable:false,identity:true),
                        ObservationId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ObservationTagsId })
                .ForeignKey("dbo.Observations", t => t.ObservationId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ObservationId)
                .Index(t => t.TagId);

            DropColumn("dbo.Observations", "Id");
            DropColumn("dbo.Tags", "Observation_Id");
            AddColumn("dbo.Observations", "ObservationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Observations", "ObservationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Observation_Id", c => c.Int());
            AddColumn("dbo.Observations", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ObservationTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ObservationTags", "ObservationId", "dbo.Observations");
            DropIndex("dbo.ObservationTags", new[] { "TagId" });
            DropIndex("dbo.ObservationTags", new[] { "ObservationId" });
            DropPrimaryKey("dbo.Observations");
            DropColumn("dbo.Observations", "ObservationId");
            DropTable("dbo.ObservationTags");
            AddPrimaryKey("dbo.Observations", "Id");
            CreateIndex("dbo.Tags", "Observation_Id");
            AddForeignKey("dbo.ObservationTags", "ObservationId", "dbo.Observations", "ObservationId", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "Observation_Id", "dbo.Observations", "Id");
        }
    }
}
