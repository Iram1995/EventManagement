namespace EventManagement.Migrations
{
    using EventManagement.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventManagement.Models.DataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventManagement.Models.DataModel context)
        {
            context.roles.AddOrUpdate(x => new {x.roleId,x.role },
                    new Role() { roleId = 1, role = "Admin" },
                    new Role() { roleId = 2, role = "Employee" }
                    );
            context.SaveChanges();
            context.genders.AddOrUpdate(x => new { x.genderId, x.gender },
                    new Gender() { genderId = 1, gender = "Male" },
                    new Gender() { genderId = 2, gender = "Female" });
            context.SaveChanges();

        }
    }
}
