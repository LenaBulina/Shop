
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyShop.Backend.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public ProductsController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            IEnumerable<Product> products = _context.Products;
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Product> GetById(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return BadRequest("Product is null.");
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if(product == null)
            {
                return BadRequest("Product is null.");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Product productToDelete = _context.Products.Find(id);

            if (productToDelete == null)
            {
                return NotFound();
            }

            _context.Remove(productToDelete);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult Update(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            Product productToDelete = _context.Products.Find(id);

            if (productToDelete == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productToDelete);
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);

        }
    }
}
