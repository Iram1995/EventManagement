namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceEventRelationshipTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceEventRelationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        eventId = c.Int(nullable: false),
                        serviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.eventId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.serviceId, cascadeDelete: true)
                .Index(t => t.eventId)
                .Index(t => t.serviceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        serviceId = c.Int(nullable: false, identity: true),
                        service = c.String(),
                        cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.serviceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceEventRelationships", "serviceId", "dbo.Services");
            DropForeignKey("dbo.ServiceEventRelationships", "eventId", "dbo.Events");
            DropIndex("dbo.ServiceEventRelationships", new[] { "serviceId" });
            DropIndex("dbo.ServiceEventRelationships", new[] { "eventId" });
            DropTable("dbo.Services");
            DropTable("dbo.ServiceEventRelationships");
        }
    }
}
