namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BalanceColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "balance", c => c.Double(nullable: false,defaultValue:0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "balance");
        }
    }
}
