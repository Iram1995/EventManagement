namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isActiveFieldAddedInEventTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "isActive", c => c.Boolean(nullable: false,defaultValue:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "isActive");
        }
    }
}
