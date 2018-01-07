using Microsoft.Owin;
using Owin;
using APM.WebAPI.Migrations;
using System.Data.Entity;
using APM.WebAPI.DataLayer;

[assembly: OwinStartup(typeof(APM.WebAPI.Startup))]

namespace APM.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            System.Data.Entity.Database.SetInitializer(
               new MigrateDatabaseToLatestVersion<TravelDataContext, Configuration>());
        }
    }
}
