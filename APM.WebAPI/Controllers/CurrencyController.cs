using APM.WebAPI.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
    public class CurrencyController : ApiController
    {
        // GET: api/Currencys
        [EnableQuery()]
        [ResponseType(typeof(Currency))]
        public IHttpActionResult Get()
        {
            try
            {
                var dataRepository = new CurrencyRepository();
                return Ok(dataRepository.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Currency/5
        [ResponseType(typeof(Currency))]
        //   [Authorize()]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Currency currency = null;
                var dataRepository = new CurrencyRepository();

                if (id > 0)
                {
                    var towns = dataRepository.Retrieve();
                    currency = towns.FirstOrDefault(p => p.Id == id);
                    if (currency == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    //product = productRepository.Create();
                }
                return Ok(currency);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        // POST: api/Currencys
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Currency data)
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

                var dataRepository = new Models.CurrencyRepository();
                var newData = dataRepository.Save(data);
                if (newData == null)
                {
                    return Conflict();
                }
                return Created<Currency>(Request.RequestUri + newData.Id.ToString(), newData);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Currencys/5
        public IHttpActionResult Put(int id, [FromBody]Currency currency)
        {
            try
            {
                if (currency == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var dataRepository = new Models.CurrencyRepository();
                var data = dataRepository.Save(id, currency);
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

        // DELETE: api/Currencys/5
        public void Delete(int id)
        {
        }
    }
}
