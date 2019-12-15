namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyRemovedFromUsersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "genderId", "dbo.Genders");
            DropForeignKey("dbo.Users", "roleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "roleId" });
            DropIndex("dbo.Users", new[] { "genderId" });
            AddColumn("dbo.Users", "gender", c => c.String());
            DropColumn("dbo.Users", "roleId");
            DropColumn("dbo.Users", "genderId");
            DropTable("dbo.Genders");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        roleId = c.Int(nullable: false, identity: true),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.roleId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        genderId = c.Int(nullable: false, identity: true),
                        gender = c.String(),
                    })
                .PrimaryKey(t => t.genderId);
            
            AddColumn("dbo.Users", "genderId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "roleId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "gender");
            CreateIndex("dbo.Users", "genderId");
            CreateIndex("dbo.Users", "roleId");
            AddForeignKey("dbo.Users", "roleId", "dbo.Roles", "roleId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "genderId", "dbo.Genders", "genderId", cascadeDelete: true);
        }
    }
}
