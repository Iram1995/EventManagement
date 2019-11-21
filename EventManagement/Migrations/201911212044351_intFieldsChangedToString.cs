namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intFieldsChangedToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "refNo", c => c.String());
            AlterColumn("dbo.Events", "cnic", c => c.String());
            AlterColumn("dbo.Events", "cellNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "cellNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "cnic", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "refNo", c => c.Int(nullable: false));
        }
    }
}
