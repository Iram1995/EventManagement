namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceToEventTableRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceEventRelationships", "eventId", "dbo.Events");
            DropForeignKey("dbo.ServiceEventRelationships", "serviceId", "dbo.Services");
            DropIndex("dbo.ServiceEventRelationships", new[] { "eventId" });
            DropIndex("dbo.ServiceEventRelationships", new[] { "serviceId" });
            DropTable("dbo.ServiceEventRelationships");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceEventRelationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        eventId = c.Int(nullable: false),
                        serviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ServiceEventRelationships", "serviceId");
            CreateIndex("dbo.ServiceEventRelationships", "eventId");
            AddForeignKey("dbo.ServiceEventRelationships", "serviceId", "dbo.Services", "serviceId", cascadeDelete: true);
            AddForeignKey("dbo.ServiceEventRelationships", "eventId", "dbo.Events", "eventId", cascadeDelete: true);
        }
    }
}
