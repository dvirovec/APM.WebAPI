using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
  
    public class ProductController : ApiController
    {
        // GET: api/Product
        
        [EnableQuery()]
        public IQueryable<Product> Get()
        {
            var productReporistory = new ProductRepository();

            return productReporistory.Retrieve().AsQueryable();
        }

        // GET: api/Product?search=        
        public IEnumerable<Product> Get(string search)
        {
            var productReporistory = new ProductRepository();

            var products = productReporistory.Retrieve();

            return products.Where(e=> e.ProductCode.Contains(search));
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            var productRepository = new ProductRepository();
            
            Product product;

            if (id > 0)
            {
                var products = productRepository.Retrieve();
                product =  products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = productRepository.Create();
            }

            return product;
        }

        // POST: api/Product
   
        public void Post([FromBody]Product product)
        {
            var productRepository = new Models.ProductRepository();
            var newProduct = productRepository.Save(product);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]Product product)
        {
            var productRepository = new Models.ProductRepository();
            var updatedProduct = productRepository.Save(id, product);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
