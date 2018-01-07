namespace APM.WebAPI.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<APM.WebAPI.DataLayer.TravelDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "APM.WebAPI.DataLayer.TravelDataContext";
        }

        protected override void Seed(APM.WebAPI.DataLayer.TravelDataContext context)
        {            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
