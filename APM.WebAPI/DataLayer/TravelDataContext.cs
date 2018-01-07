using System.Data.Entity;
using APM.WebAPI.Models;

namespace APM.WebAPI.DataLayer
{
    public class TravelDataContext:DbContext
    {
        public DbSet<Town> Towns { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}