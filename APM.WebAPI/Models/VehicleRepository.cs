using APM.WebAPI.DataLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;

namespace APM.WebAPI.Models
{
    /// <summary>
    /// Stores the data in a json file so that no database is required for this
    /// sample application
    /// </summary>
    public class VehicleRepository
    {
        /// <summary>
        /// Creates a new product with default values
        /// </summary>
        /// <returns></returns>
        internal Vehicle Create()
        {
            Vehicle vehicle = new Vehicle
            {      };
            return vehicle;
        }

        /// <summary>
        /// Retrieves the list of products.
        /// </summary>
        /// <returns></returns>
        internal List<Vehicle> Retrieve()
        {

            var context = new TravelDataContext();

            var vehicles = context.Vehicles.ToList();

            /* file based 
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/vehicle.json");
            var json = System.IO.File.ReadAllText(filePath);
            var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json);*/

            return vehicles;
        }

        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        internal Vehicle Save(Vehicle vehicle)
        {
            // Read in the existing products
            var vehicles = this.Retrieve();

            // Assign a new Id
            var maxId = vehicles.Max(p => p.Id);
            vehicle.Id = maxId + 1;
            vehicles.Add(vehicle);

            WriteData(vehicles);
            return vehicle;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        internal Vehicle Save(int id, Vehicle vehicle)
        {
            // Read in the existing products
            var vehicles = this.Retrieve();

            // Locate and replace the item
            var itemIndex = vehicles.FindIndex(p => p.Id == vehicle.Id);
            if (itemIndex > 0)
            {
                vehicles[itemIndex] = vehicle;
            }
            else
            {
                return null;
            }

            WriteData(vehicles);
            return vehicle;
        }


        private bool WriteData(List<Vehicle> vehicles)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/vehicle.json");

            var json = JsonConvert.SerializeObject(vehicles, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }

    }
}