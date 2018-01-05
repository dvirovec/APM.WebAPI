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
    public class TownRepository
    {
        /// <summary>
        /// Creates a new product with default values
        /// </summary>
        /// <returns></returns>
        internal Town Create()
        {
            Town town = new Town
            { };
            return town;
        }

        /// <summary>
        /// Retrieves the list of products.
        /// </summary>
        /// <returns></returns>
        internal List<Town> Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/town.json");
            var json = System.IO.File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<Town>>(json);
            return data;
        }

        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="town"></param>
        /// <returns></returns>
        internal Town Save(Town town)
        {
            // Read in the existing products
            var data = this.Retrieve();

            // Assign a new Id
            var maxId = data.Max(p => p.Id);
            town.Id = maxId + 1;
            data.Add(town);

            WriteData(data);
            return town;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        internal Town Save(int id, Town town)
        {
            // Read in the existing products
            var data = this.Retrieve();

            // Locate and replace the item
            var itemIndex = data.FindIndex(p => p.Id == town.Id);
            if (itemIndex > 0)
            {
                data[itemIndex] = town;
            }
            else
            {
                return null;
            }

            WriteData(data);
            return town;
        }


        private bool WriteData(List<Town> vehicles)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/town.json");

            var json = JsonConvert.SerializeObject(vehicles, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }

    }
}