namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SellFactorController : ControllerBase
{
    private readonly SellFactorService _sellfactorservice;
    public SellFactorController(SellFactorService _sellfactorservice)
    {
        this._sellfactorservice = _sellfactorservice;
    }

    [HttpGet]
    public async Task<ActionResult<List<SellFactor>>> Get()
    {
        try
        {
            return StatusCode(200, await _sellfactorservice.GetSellFactorsAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SellFactor>> Get(string id)
    {
        try
        {
            return StatusCode(200, await _sellfactorservice.GetSellFactorDetailsAsync(id));
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] SellFactor SellFactor)
    {
        try
        {
            await _sellfactorservice.CreateSellFactorAsync(SellFactor);
            return StatusCode(200, SellFactor);
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
            await _sellfactorservice.DeleteSellFactorAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SellFactor sellFactor, string user, [FromRoute] productFactors[] productFactors, double offer, DateTime dates, double totalPrice, bool statusPayment, string description, string satisfaction)
    {
        try
        {
            await _sellfactorservice.update(sellFactor, user, productFactors, offer, dates, totalPrice, statusPayment, description, satisfaction);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
