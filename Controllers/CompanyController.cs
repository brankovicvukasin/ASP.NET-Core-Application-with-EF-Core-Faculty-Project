namespace WebProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        public ApplicationContext Context { get; set; }

        public CompanyController(ApplicationContext context)
        {
            Context = context;
        }

        [HttpGet("getCompanies")]
        public async Task<ActionResult<List<Company>>> GetCompanies()
        {
            return Ok(await Context.Companies.ToListAsync());
        }

        [HttpGet("getItem/{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await Context.Items.FindAsync(id);
            if (item == null)
                return NotFound("Item not found");
            return Ok(item);
        }

        [HttpGet("getVehicle/{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await Context.Vehicles.FindAsync(id);
            if (vehicle == null)
                return NotFound("Vehicle not found");
            return Ok(vehicle);
        }

        [Route("addItem")]
        [HttpPost]
        public async Task<ActionResult> AddItem([FromBody] Item item)
        {
            if (item == null)
                return BadRequest("Non existent item");

            try
            {
                await Context.Items.AddAsync(item);
                await Context.SaveChangesAsync();

                return Ok($"Item is added with ID:{item.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("addCompany")]
        [HttpPost]
        public async Task<ActionResult> AddCompany([FromBody] Company company)
        {
            if (company == null)
                return BadRequest("Non existent company");

            try
            {
                await Context.Companies.AddAsync(company);
                await Context.SaveChangesAsync();

                return Ok($"Company is added with id:{company.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("addVehicle")]
        [HttpPost]
        public async Task<ActionResult> AddVehicle([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest("Non existend vehicle");

            try
            {
                await Context.Vehicles.AddAsync(vehicle);
                await Context.SaveChangesAsync();

                return Ok($"Vehicle is added with id:{vehicle.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("findItem/{idItem}")]
        [HttpGet]
        public async Task<ActionResult> FindItem(int idItem)
        {
            var item = await Context.Items.Where(p => p.Id == idItem).FirstOrDefaultAsync();
            if (item == null)
                return BadRequest("Non existent item");

            var company = await Context
                .Companies.Where(p => p.Price > item.PriceFrom && p.Price < item.PriceTo)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    AverageEarnings = p.AverageEarnings
                })
                .FirstOrDefaultAsync();
            if (company == null)
                return BadRequest("Company is not existent");
            return Ok(company);
        }

        [Route("deliver/{idK}")]
        [HttpPut]
        public async Task<ActionResult> Deliver(int idK)
        {
            var company = await Context.Companies.Where(p => p.Id == idK).FirstOrDefaultAsync();
            if (company == null)
                return BadRequest("Non existent company");

            try
            {
                company.AverageEarnings += company.Price;
                await Context.SaveChangesAsync();
                return Ok(company);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("deleteCompany/{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var company = await Context.Companies.FindAsync(id);
            if (company == null)
                return NotFound("Company not found");

            Context.Companies.Remove(company);
            await Context.SaveChangesAsync();
            return Ok($"Company with ID {id} deleted");
        }

        [HttpDelete("deleteItem/{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var item = await Context.Items.FindAsync(id);
            if (item == null)
                return NotFound("Item not found");

            Context.Items.Remove(item);
            await Context.SaveChangesAsync();
            return Ok($"Item with ID {id} deleted");
        }

        [HttpDelete("deleteVehicle/{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            var vehicle = await Context.Vehicles.FindAsync(id);
            if (vehicle == null)
                return NotFound("Vehicle not found");

            Context.Vehicles.Remove(vehicle);
            await Context.SaveChangesAsync();
            return Ok($"Vehicle with ID {id} deleted");
        }
    }
}
