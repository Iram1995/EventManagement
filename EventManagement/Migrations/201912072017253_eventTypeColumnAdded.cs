namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventTypeColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "eventType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "eventType");
        }
    }
}
