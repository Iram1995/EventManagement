namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventTimeFieldRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "EventTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventTime", c => c.DateTime(nullable: false));
        }
    }
}
