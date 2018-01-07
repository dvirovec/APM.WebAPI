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
    public class CurrencyRepository
    {
        /// <summary>
        /// Creates a new product with default values
        /// </summary>
        /// <returns></returns>
        internal Currency Create()
        {
            Currency currency = new Currency
            { };
            return currency;
        }

        /// <summary>
        /// Retrieves the list of products.
        /// </summary>
        /// <returns></returns>
        internal List<Currency> Retrieve()
        {
            List<Currency> currencies = null;

            using (var context = new TravelDataContext()) {
              currencies =  context.Currencies.ToList();               
            }
            
            /*
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/currency.json");
            var json = System.IO.File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<Currency>>(json);*/

            return currencies;
        }

        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        internal Currency Save(Currency currency)
        {
            // Read in the existing products
            var data = this.Retrieve();

            // Assign a new Id
            var maxId = data.Max(p => p.Id);
            currency.Id = maxId + 1;
            data.Add(currency);

            WriteData(data);
            return currency;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        internal Currency Save(int id, Currency currency)
        {
            // Read in the existing products
            var data = this.Retrieve();

            // Locate and replace the item
            var itemIndex = data.FindIndex(p => p.Id == currency.Id);
            if (itemIndex > 0)
            {
                data[itemIndex] = currency;
            }
            else
            {
                return null;
            }

            WriteData(data);
            return currency;
        }


        private bool WriteData(List<Currency> vehicles)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/currency.json");

            var json = JsonConvert.SerializeObject(vehicles, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }

    }
}