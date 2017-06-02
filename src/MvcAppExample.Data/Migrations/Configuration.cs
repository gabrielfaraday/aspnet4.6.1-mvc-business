using MvcAppExample.Data.Contexts;
using System.Data.Entity.Migrations;

namespace MvcAppExample.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MainContext context)
        {
            
        }
    }
}
