namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuEventRelationships",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        isActive = c.Boolean(nullable: false,defaultValue:true),
                        menuId = c.Int(nullable: false),
                        eventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Events", t => t.eventId, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.menuId, cascadeDelete: true)
                .Index(t => t.menuId)
                .Index(t => t.eventId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        menuId = c.Int(nullable: false, identity: true),
                        menu = c.String(),
                    })
                .PrimaryKey(t => t.menuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuEventRelationships", "menuId", "dbo.Menus");
            DropForeignKey("dbo.MenuEventRelationships", "eventId", "dbo.Events");
            DropIndex("dbo.MenuEventRelationships", new[] { "eventId" });
            DropIndex("dbo.MenuEventRelationships", new[] { "menuId" });
            DropTable("dbo.Menus");
            DropTable("dbo.MenuEventRelationships");
        }
    }
}
