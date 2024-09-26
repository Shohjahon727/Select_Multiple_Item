using Microsoft.AspNetCore.Mvc;
using Select_Multiple_Item.Data;
using Select_Multiple_Item.Entities;
using Select_Multiple_Item.Enums;
using System.Linq;

namespace Select_Multiple_Item.Controllers;

public class CarController : Controller
{
    private readonly AppDbContext _context;

    public CarController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        var allCars = _context.Cars.ToList();


        return View(allCars);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Car car)
    {
		if(ModelState.IsValid)
		{
			_context.Cars.Add(car);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
        return View(car);
    }

	//[HttpGet]
	public IActionResult FilterByColor(string[] filterbycolor)
    {

        if (filterbycolor.Length == 0)
        {

            var allCars = _context.Cars.ToList();
            return View("Index", allCars);
        }

        List<Colors> colors = new List<Colors>();
        foreach (var item in filterbycolor)
        {
            colors.Add((Colors)Enum.Parse(typeof(Colors), item, true));
        }


        var filteredCars = _context.Cars
            .Where(car => colors.Contains(car.Color))
            .ToList();

        return View("Index", filteredCars);
    }
	public IActionResult FilterByManufacturer(string[] filterbymanufacturer)
	{
		if (filterbymanufacturer.Length == 0)
		{
			var allCars = _context.Cars.ToList();
			return View("Index", allCars);
		}
		List<Manufacturers> manufacturers = new List<Manufacturers>();
		foreach (var item in filterbymanufacturer)
		{
			manufacturers.Add((Manufacturers)Enum.Parse(typeof(Manufacturers), item, true));
		}
		var filteredCars = _context.Cars
			.Where(car => manufacturers.Contains(car.Manufacturer))
			.ToList();
		return View("Index", filteredCars);
	}

	//[HttpGet]
	public IActionResult FilterByPrice(string[] filterbyprice)
	{

		if (filterbyprice.Length == 0)
		{

			var allCars = _context.Cars.ToList();
			return View("Index", allCars);
		}

		List<Prices> colors = new List<Prices>();
		foreach (var item in filterbyprice)
		{
			colors.Add((Prices)Enum.Parse(typeof(Prices), item, true));
		}


		var filteredCars = _context.Cars
			.Where(car => colors.Contains((Prices)car.Price))
			.ToList();

		return View("Index", filteredCars);
	}
    [HttpGet]
	public IActionResult Filter(string[] filterbycolor, string[] filterbyprice, string[] filterbymanufacturer)
	{
		
		if ((filterbycolor == null || filterbycolor.Length == 0) && (filterbyprice == null || filterbyprice.Length == 0) && (filterbymanufacturer == null || filterbymanufacturer.Length ==0))
		{
			var allCars = _context.Cars.ToList();
			return View("Index", allCars);
		}

		
		List<Colors> colors = new List<Colors>();
		if (filterbycolor != null && filterbycolor.Length > 0)
		{
			foreach (var item in filterbycolor)
			{
				colors.Add((Colors)Enum.Parse(typeof(Colors), item, true));
			}
		}

		
		List<Prices> prices = new List<Prices>();
		if (filterbyprice != null && filterbyprice.Length > 0)
		{
			foreach (var item in filterbyprice)
			{
				prices.Add((Prices)Enum.Parse(typeof(Prices), item, true));
			}
		}

		List<Manufacturers> manufacturers = new List<Manufacturers>();
		if(filterbymanufacturer != null && filterbymanufacturer.Length > 0)
		{
			foreach (var item in filterbymanufacturer)
			{
				manufacturers.Add((Manufacturers)(Enum.Parse(typeof(Manufacturers), item, true)));
			}
		}
		
		var filteredCars = _context.Cars
			.Where(car => (colors.Count == 0 || colors.Contains(car.Color)) && 
						  (prices.Count == 0 || prices.Contains((Prices)car.Price)) &&
						  (manufacturers.Count == 0 || manufacturers.Contains(car.Manufacturer))) 
			.ToList();

		return View("Index", filteredCars);
	}
	[HttpGet]
	public IActionResult PriceRange(decimal MinPrice, decimal MaxPrice)
	{

		var filteredCars = _context.Cars
									.Where(a => a.Price >= MinPrice && a.Price <= MaxPrice)
									.ToList();

		return View("Index", filteredCars);
	}


}
