namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventTimeColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventTime");
        }
    }
}
