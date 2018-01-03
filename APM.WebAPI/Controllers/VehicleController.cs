using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
    
    public class Controller : ApiController
    {
        // GET: api/Vehicles
        [EnableQuery()]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult Get()
        {
            try
            {
                var vehicleRepository = new VehicleRepository();
                return Ok(vehicleRepository.Retrieve().AsQueryable());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Vehicle/5
        [ResponseType(typeof(Vehicle))]
     //   [Authorize()]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Vehicle vehicle = null;
                var vehicleRepository = new VehicleRepository();

                if (id > 0)
                {
                    var vehicles = vehicleRepository.Retrieve();
                    vehicle = vehicles.FirstOrDefault(p => p.id == id);
                    if (vehicle == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    //product = productRepository.Create();
                }
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }





        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productRepository = new Models.ProductRepository();
                var newProduct = productRepository.Save(product);
                if (newProduct == null)
                {
                    return Conflict();
                }
                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(),
                    newProduct);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productRepository = new Models.ProductRepository();
                var updatedProduct = productRepository.Save(id, product);
                if (updatedProduct == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
