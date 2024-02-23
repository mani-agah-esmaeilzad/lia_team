namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BuyFactorController : ControllerBase
{
    private readonly BuyFactorService _buyFactorService;
    public BuyFactorController(BuyFactorService _buyFactorService)
    {
        this._buyFactorService = _buyFactorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BuyFactor>>> Get()
    {
        try
        {
            return StatusCode(200, await _buyFactorService.GetBuyFactorsAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BuyFactor>> Get(string id)
    {
        try
        {
            return StatusCode(200, await _buyFactorService.GetBuyFactorDetailsAsync(id));
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] BuyFactor buyFactor)
    {
        try
        {
            await _buyFactorService.CreateBuyFactorAsync(buyFactor);
            return StatusCode(200, buyFactor);
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
            await _buyFactorService.DeleteBuyFactorAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound();
        }

    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] BuyFactor BuyFactor, DateTime date,[FromRoute] productFactors[] products, double totalPrice)
    {
        try
        {
            await _buyFactorService.update(BuyFactor, date, products, totalPrice);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

}
