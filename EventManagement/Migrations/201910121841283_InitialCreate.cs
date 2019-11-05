namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        genderId = c.Int(nullable: false, identity: true),
                        gender = c.String(),
                    })
                .PrimaryKey(t => t.genderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        password = c.String(),
                        email = c.String(),
                        roleId = c.Int(nullable: false),
                        genderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userId)
                .ForeignKey("dbo.Genders", t => t.genderId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.roleId, cascadeDelete: true)
                .Index(t => t.roleId)
                .Index(t => t.genderId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        roleId = c.Int(nullable: false, identity: true),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.roleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "roleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "genderId", "dbo.Genders");
            DropIndex("dbo.Users", new[] { "genderId" });
            DropIndex("dbo.Users", new[] { "roleId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Genders");
        }
    }
}
