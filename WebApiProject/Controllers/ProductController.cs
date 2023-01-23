using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return products;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return products.Single(x=> x.Id == id);
        }

        [HttpPost]
        public ActionResult Create (Product model)
        {
            model.Id = products.Count()+1; 
            products.Add(model);

            return CreatedAtAction(
                "Get",
                new { id = model.Id }, 
                model
                );
        }

        [HttpPut("{productId}")]
        public ActionResult Update(int productId, Product model)
        {
            var originalEntry = products.Single(x => x.Id == productId);
            originalEntry.Name = model.Name;
            originalEntry.Description = model.Description;
            originalEntry.Price = model.Price;

            return NoContent();
        }

        [HttpDelete("productId")]
        public ActionResult Delete(int productId)
        {
            products = products.Where(x => x.Id != productId).ToList();

            return NoContent();
        }

        public static  List<Product> products= new List<Product>
        {
            new Product
            {
                Id= 1,
                Name = "Guitarra eléctrica",
                Price = 1200,
                Description = "Ideal para tocar jazz, blues, rock clásico y afines."
            },
            new Product
            {
                Id= 2,
                Name = "Amplificador para guiarra eléctrica",
                Price = 1200,
                Description = "Excelente amplicador con un sonido cálido"
            }
        };
    }
}
