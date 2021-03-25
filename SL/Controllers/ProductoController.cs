using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("api/Producto")]
        // GET: api/Producto
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAllProducto();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Producto/{SKU}")]
        // GET: api/Producto/5
        public IHttpActionResult GetBySKU(string SKU)
        {
            ML.Result result = BL.Producto.GetBySKUProducto(SKU);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Producto")]
        // POST: api/Producto
        public IHttpActionResult Add([FromBody]ML.Producto producto)
        {
            ML.Result result = BL.Producto.AddProducto(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/Producto/")]
        // PUT: api/Producto/5
        public IHttpActionResult Update([FromBody]ML.Producto producto)
        {
            ML.Result result = BL.Producto.UpdateProducto(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/Producto/{SKU}")]
        // DELETE: api/Producto/5
        public IHttpActionResult Delete(string SKU)
        {
            ML.Result result = BL.Producto.DeleteProducto(SKU);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
