using CarCollectionWeb.Data;
using CarCollectionWeb.Models;
using CarCollectionWeb.Models.Domain;
using CarCollectionWeb.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarCollectionWeb.Controllers
{
    public class CarsController : Controller
    {
        private readonly MotorShowDbContext motorShowDbContext;

        public CarsController(MotorShowDbContext motorShowDbContext)
        {
            this.motorShowDbContext = motorShowDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var carBrands = new CarsViewModel();

            carBrands.BrandsDictionary = motorShowDbContext.Cars
                .Where(x => x.CarBrand != null)
                .Select(c => c.CarBrand)
                .Distinct()
                .ToList();

            return View(carBrands);
        }

        [HttpGet]
        public ActionResult FilterByCarBrand(string carBrand, int page = 1, int pageSize = 5)
        {
            var query = motorShowDbContext.Cars.Include(c => c.CarCategory).AsQueryable();
            if (!String.IsNullOrEmpty(carBrand))
            {
                query = query.Where(c => c.CarBrand == carBrand);
            }
            var filteredCars = query
                .OrderBy(c => c.CarBrand)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();

            var totalCars = query.Count();

            var carViewModels = filteredCars
                 .Select(x => new CarViewModel
                 {
                     Id = x.Id,
                     CarBrand = x.CarBrand,
                     CarModel = x.CarModel,
                     Year = x.Year,
                     EngineСapacity = x.EngineСapacity,
                     FuelType = x.FuelType,
                     CarCategoryViewModel = new CarCategoryViewModel
                     {
                         NameCategory = x.CarCategory.NameCategory
                     }
                 }).ToList();

            var pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalCars,
            };

            var viewModel = new PageInfoViewModel
            {
                Cars = carViewModels,
                PageInfo = pageInfo,
            };

            return Json(viewModel);
        }

        //   [HttpGet]
        //  public async Task<IActionResult> Index(string carBrand, int page = 1, int pageSize = 5)
        //  {
        //
        //      var totalCars = await motorShowDbContext.Cars.CountAsync();
        //
        //      var cars = await motorShowDbContext.Cars
        //          .Include(c => c.CarCategory)
        //          .OrderBy(c => c.CarBrand)
        //          .Skip((page - 1) * pageSize)
        //          .Take(pageSize)
        //          .ToListAsync();
        //
        //      var carViewModels = cars
        //          .Select(x => new CarViewModel
        //          {
        //              Id = x.Id,
        //              CarBrand = x.CarBrand,
        //              CarModel = x.CarModel,
        //              Year = x.Year,
        //              EngineСapacity = x.EngineСapacity,
        //              FuelType = x.FuelType,
        //              CarCategoryViewModel = new CarCategoryViewModel
        //              {
        //                  NameCategory = x.CarCategory.NameCategory
        //              }
        //          }).ToList();
        //
        //      var pageInfo = new PageInfo
        //      {
        //          PageNumber = page,
        //          PageSize = pageSize,
        //          TotalItems = totalCars,
        //      };
        //      // ViewBag.PageInfo = pageInfo;
        //
        //      var viewModel = new PageInfoViewModel
        //      {
        //          Cars = carViewModels,
        //          PageInfo = pageInfo,
        //      };
        //
        //
        //      return View(viewModel);
        //  }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int Id)
        {

            //Add Car
            if (Id <= 0)
            {
                var modelAdd = new CarViewModel();
                var carCategories = motorShowDbContext.CarCategorys.ToList();
                modelAdd.CarCategoriesName = carCategories.Select(c => new CarCategoryViewModel { Id = c.Id, NameCategory = c.NameCategory });

                return await Task.Run(() => View("Add", modelAdd));
            }
            //Edit Car
            else
            {
                var car = await motorShowDbContext.Cars.FindAsync(Id);
                if (car != null)
                {
                    var modelEdit = new CarViewModel()
                    {
                        Id = car.Id,
                        CarBrand = car.CarBrand,
                        CarModel = car.CarModel,
                        Year = car.Year,
                        EngineСapacity = car.EngineСapacity,
                        FuelType = car.FuelType,
                        CarCategoryId = car.CarCategoryId,
                        CarCategoriesName = motorShowDbContext.CarCategorys
                    .Select(x => new CarCategoryViewModel { Id = x.Id, NameCategory = x.NameCategory })
                    .ToList()
                    };

                    return await Task.Run(() => View("Edit", modelEdit));
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(CarViewModel addCarRequest)
        {
            //Add Car
            if (addCarRequest.Id <= 0)
            {
                var car = new Car()
                {
                    CarBrand = addCarRequest.CarBrand,
                    CarModel = addCarRequest.CarModel,
                    Year = addCarRequest.Year,
                    EngineСapacity = addCarRequest.EngineСapacity,
                    FuelType = addCarRequest.FuelType,
                    CarCategoryId = addCarRequest.CarCategoryId
                };

                static void GenerateRandomRecords(int recordCount)
                {
                    using (var dbContext = new MotorShowDbContext()) // Замените YourDbContext на ваш контекст базы данных
                    {
                        var random = new Random();

                        for (int i = 0; i < recordCount; i++)
                        {
                            var car = new Car
                            {
                                CarBrand = RandomCars.GenerateRandomCarBrand(random),
                                CarModel = RandomCars.GenerateRandomCarModel(random),
                                Year = RandomCars.GenerateRandomYear(random, 2000, 2022),
                                EngineСapacity = (int)RandomCars.GenerateRandomEngineCapacity(random, 1.0, 4.0),
                                //FuelType = GenerateRandomFuelType(random)
                            };

                            dbContext.Cars.Add(car);
                        }

                        dbContext.SaveChanges();
                    }
                }

                // Использование функции генерации случайных записей
                int recordCount = 10; // Количество желаемых случайных записей
                GenerateRandomRecords(recordCount);

                await motorShowDbContext.Cars.AddAsync(car);
                await motorShowDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //Edit Car
            else
            {
                var car = await motorShowDbContext.Cars.FindAsync(addCarRequest.Id);
                if (car != null)
                {

                    car.CarBrand = addCarRequest.CarBrand;
                    car.CarModel = addCarRequest.CarModel;
                    car.Year = addCarRequest.Year;
                    car.EngineСapacity = addCarRequest.EngineСapacity;
                    car.FuelType = addCarRequest.FuelType;
                    car.CarCategoryId = addCarRequest.CarCategoryId;
                }

                await motorShowDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var car = await motorShowDbContext.Cars.FindAsync(Id);

            if (car != null)
            {
                motorShowDbContext.Cars.Remove(car);
                await motorShowDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}



