using Microsoft.AspNetCore.Mvc;

namespace GoStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public ProductsController() 
        { }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            return Ok("done");
        }
    }
}