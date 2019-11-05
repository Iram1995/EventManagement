namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventId = c.Int(nullable: false, identity: true),
                        refNo = c.Int(nullable: false),
                        cnic = c.Int(nullable: false),
                        cellNo = c.Int(nullable: false),
                        MS = c.String(),
                        createdDate = c.DateTime(nullable: false),
                        createdBy = c.Int(nullable: false),
                        modifiedBy = c.Int(nullable: false),
                        modifiedDate = c.DateTime(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        notes = c.String(),
                        noOfPeople = c.Int(nullable: false),
                        perHead = c.Double(nullable: false),
                        totalAmount = c.Double(nullable: false,defaultValue:0),
                        grandTotal = c.Double(defaultValue: 0),
                        advance = c.Double(nullable: false,defaultValue:0),
                        Received = c.Double(nullable: false,defaultValue: 0),
                    })
                .PrimaryKey(t => t.eventId)
                .ForeignKey("dbo.Users", t => t.createdBy, cascadeDelete: true)
                .Index(t => t.createdBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "createdBy", "dbo.Users");
            DropIndex("dbo.Events", new[] { "createdBy" });
            DropTable("dbo.Events");
        }
    }
}
