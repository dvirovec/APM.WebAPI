using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using APM.WebAPI.Models;

namespace APM.WebAPI.DataLayer
{
    public class TravelDataContext:DbContext
    {
        public DbSet<Town> Towns { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }        
    }
}