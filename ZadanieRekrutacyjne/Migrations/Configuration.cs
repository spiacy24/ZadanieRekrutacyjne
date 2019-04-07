namespace ZadanieRekrutacyjne.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ZadanieRekrutacyjne.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZadanieRekrutacyjne.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZadanieRekrutacyjne.Models.ApplicationDbContext context)
        {
            AddUsers(context);
        }

       void AddUsers(ZadanieRekrutacyjne.Models.ApplicationDbContext context)
        {
            var user = new ApplicationUser { UserName = "user@email.com" };
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            usermanager.Create(user, "password");
        }
    }
}
