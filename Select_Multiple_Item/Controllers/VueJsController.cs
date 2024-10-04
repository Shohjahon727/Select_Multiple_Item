using Microsoft.AspNetCore.Mvc;
using Select_Multiple_Item.Data;
using Select_Multiple_Item.Entities;
using Select_Multiple_Item.Enums;


namespace Select_Multiple_Item.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VueJsController : ControllerBase
	{
        private readonly AppDbContext _context;

        public VueJsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars()
        {
            var allCars = _context.Cars.ToList();
            return Ok(allCars);
        }

        [HttpPost]
        public ActionResult<Car> CreateCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cars.Add(car);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = _context.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<object>> Filter(
            [FromQuery] string[] filterbycolor,
            [FromQuery] string[] filterbymanufacturer,
            [FromQuery] decimal? MinPrice,
            [FromQuery] decimal? MaxPrice)
        {
            var query = _context.Cars.AsQueryable();

            if (filterbycolor != null && filterbycolor.Length > 0)
            {
                var colors = filterbycolor.Select(c => Enum.Parse<Colors>(c)).ToList();
                query = query.Where(car => colors.Contains(car.Color));
            }

            if (filterbymanufacturer != null && filterbymanufacturer.Length > 0)
            {
                var manufacturers = filterbymanufacturer.Select(m => Enum.Parse<Manufacturers>(m)).ToList();
                query = query.Where(car => manufacturers.Contains(car.Manufacturer));
            }

            if (MinPrice.HasValue)
            {
                query = query.Where(car => car.Price >= MinPrice.Value);
            }

            if (MaxPrice.HasValue)
            {
                query = query.Where(car => car.Price <= MaxPrice.Value);
            }

            var filteredCars = query.Select(car => new
            {
                Id = car.Id,
                Color = car.Color.ToString(),
                Manufacturer = car.Manufacturer.ToString(),
                Model = car.Model,
                Price = car.Price,
            }).ToList();

            return Ok(new
            {
                data = filteredCars,
                selectedColors = filterbycolor ?? new string[0],
                selectedManufacturers = filterbymanufacturer ?? new string[0]
            });
        }

        [HttpGet("pricerange")]
        public ActionResult<IEnumerable<Car>> PriceRange([FromQuery] decimal MinPrice, [FromQuery] decimal MaxPrice)
        {
            var filteredCars = _context.Cars
                .Where(a => a.Price >= MinPrice && a.Price <= MaxPrice)
                .ToList();

            return Ok(filteredCars);
        }

        //// GET: api/<VueJs1Controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //	return new string[] { "value1", "value2" };
        //}

        //// GET api/<VueJs1Controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //	return "value";
        //}

        //// POST api/<VueJs1Controller>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<VueJs1Controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<VueJs1Controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
