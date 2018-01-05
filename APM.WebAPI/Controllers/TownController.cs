using APM.WebAPI.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
    public class TownController : ApiController
    {
        // GET: api/Towns
        [EnableQuery()]
        [ResponseType(typeof(Town))]
        public IHttpActionResult Get()
        {
            try
            {
                var dataRepository = new TownRepository();
                return Ok(dataRepository.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Town/5
        [ResponseType(typeof(Town))]
        //   [Authorize()]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Town town = null;
                var dataRepository = new TownRepository();

                if (id > 0)
                {
                    var towns = dataRepository.Retrieve();
                    town = towns.FirstOrDefault(p => p.Id == id);
                    if (town == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    //product = productRepository.Create();
                }
                return Ok(town);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        // POST: api/Towns
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Town data)
        {
            try
            {
                if (data == null)
                {
                    return BadRequest("Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var dataRepository = new Models.TownRepository();
                var newData = dataRepository.Save(data);
                if (newData == null)
                {
                    return Conflict();
                }
                return Created<Town>(Request.RequestUri + newData.Id.ToString(), newData);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Towns/5
        public IHttpActionResult Put(int id, [FromBody]Town town)
        {
            try
            {
                if (town == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var dataRepository = new Models.TownRepository();
                var data = dataRepository.Save(id, town);
                if (data == null)
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

        // DELETE: api/Towns/5
        public void Delete(int id)
        {
        }
    }
}
