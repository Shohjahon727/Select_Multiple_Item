using Microsoft.AspNetCore.Mvc;
using Select_Multiple_Item.Data;
using Select_Multiple_Item.Entities;
using Select_Multiple_Item.Enums;
using Select_Multiple_Item.Models;

namespace Select_Multiple_Item.Controllers;
public class CarWithVueJsController : Controller
{


    private readonly AppDbContext _context;

    public CarWithVueJsController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        
        var allCars = _context.Cars.ToList();

        
        return View((allCars, new List<string>(),new List<string>())); 
    }
    public IActionResult FilterByColor( string[] filterbycolor)
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
    public IActionResult FilterByManufacturer( string[] filterbymanufacturer)
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

    [HttpGet]
    public IActionResult Filter([FromQuery] string? filterbycolor,[FromQuery] string? filterbymanufacturer,[FromQuery] decimal? MinPrice,[FromQuery] decimal? MaxPrice)
    {
        var query = _context.Cars.AsQueryable();
        var filterColors = filterbycolor?.Split(',');
        var filterManufacturers = filterbymanufacturer?.Split(',');
        List<Colors> colors = new List<Colors>();
        List<Manufacturers> manufacturers = new List<Manufacturers>();
        if (filterColors != null && filterColors.Length > 0)
        {
            colors = filterColors.Select(c => Enum.Parse<Colors>(c)).ToList();
            query = query.Where(car => colors.Contains(car.Color));
        }

        if (filterManufacturers != null && filterManufacturers.Length > 0)
        {
            manufacturers = filterManufacturers.Select(m => Enum.Parse<Manufacturers>(m)).ToList();
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
            Color = car.Color,
            Manufacturer = car.Manufacturer,
            Model = car.Model,
            Price = car.Price,

        }).ToList();

        return Json(new
        {
            data = filteredCars,
            selectedColors = colors,
            selectedManufacturers = manufacturers 
        });
    }
    public IActionResult PriceRange(decimal MinPrice, decimal MaxPrice)
    {

        var filteredCars = _context.Cars
                                    .Where(a => a.Price >= MinPrice && a.Price <= MaxPrice)
                                    .ToList();

        return View("Index", filteredCars);
    }


}

