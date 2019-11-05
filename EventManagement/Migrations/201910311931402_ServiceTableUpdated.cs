namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "isActive", c => c.Boolean(nullable: false,defaultValue:true));
            AddColumn("dbo.Services", "event_Id", c => c.Int(nullable:true));
            CreateIndex("dbo.Services", "event_Id");
            AddForeignKey("dbo.Services", "event_Id", "dbo.Events", "eventId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "event_Id", "dbo.Events");
            DropIndex("dbo.Services", new[] { "event_Id" });
            DropColumn("dbo.Services", "event_Id");
            DropColumn("dbo.Services", "isActive");
        }
    }
}
