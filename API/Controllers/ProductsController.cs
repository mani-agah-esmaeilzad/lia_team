namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService _productService)
        {
            this._productService = _productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                return StatusCode(200, await _productService.GetProductAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            try
            {
                return StatusCode(200, await _productService.getProductDetailsAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            try
            {
                await _productService.CreateProductAsync(product);
                return StatusCode(200, product);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update( Product product, string name, string barcode, int sellPrice, int BuyPrice, int count, string pv, string category)
        {
            try
            {
                await _productService.UpdateProductAsync(product,name,barcode,sellPrice,BuyPrice,count,pv,category);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(401,ex.Message);
            }
        }
    }
}
