using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels;
using ExpressVoitures.Models.Repositories;
using ExpressVoitures.Models.Services;

namespace ExpressVoitures.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBrandRepository _brandRepository;
        private readonly IModeleRepository _modeleRepository;
        private readonly IFinitionRepository _finitionRepository;
        private readonly IYearRepository _yearRepository;
        private readonly ICarsService _carService;

        public CarsController(ApplicationDbContext context, IBrandRepository brandRepository,IModeleRepository modeleRepository, IFinitionRepository finitionRepository, IYearRepository yearRepository, ICarsService carService)
        {
            _context = context;
            _brandRepository= brandRepository;
            _modeleRepository= modeleRepository;
            _finitionRepository= finitionRepository;
            _yearRepository= yearRepository;
            _carService= carService;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cars.Include(c => c.Brand).Include(c => c.Finition).Include(c => c.Modele).Include(c => c.Year);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Finition)
                .Include(c => c.Modele)
                .Include(c => c.Year)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {

            PopulateDropdownLists();

             return View();
           
            
        }
        [HttpGet]
        public JsonResult GetModelsByBrand(int brandId)
        {
            var models = _modeleRepository.GetModelsByBrandId(brandId)
                            .Select(m => new SelectListItem
                            {
                                Value = m.Id.ToString(),
                                Text = m.Name
                            })
                            .ToList();

            return Json(models);
        }
           private void PopulateDropdownLists()
            {
                ViewData["BrandId"] = _brandRepository.GetBrands();

                ViewData["FinitionId"] = _finitionRepository.GetFinitions();

                //ViewData["ModelId"] = _modeleRepository.GetModels();

                ViewData["YearId"] = _yearRepository.GetYears();
            }
       /* private void PopulateDropdownLists(CarViewModel carViewModel)
        {
            ViewData["YearId"] = new SelectList(_yearRepository.GetYears(), "Id", "YearValue", carViewModel?.YearId);
            ViewData["BrandId"] = new SelectList(_brandRepository.GetBrands(), "Id", "BrandName", carViewModel?.BrandId);

            if (carViewModel?.BrandId != null)
            {
                ViewData["ModelId"] = new SelectList(_modeleRepository.GetModelsByBrandId(carViewModel.BrandId), "Id", "Name", carViewModel.ModelId);
            }
            else
            {
                ViewData["ModelId"] = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            }

            ViewData["FinitionId"] = new SelectList(_finitionRepository.GetFinitions(), "Id", "Name", carViewModel?.FinitionId);
        }*/
        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,YearId,BrandId,ModelId,FinitionId,DateOfPurchase,PurchasePrice,Repair,RepairPrice,DateOfAvailabilityForSale,SellingPrice,DateOfSale")] CarViewModel carViewModel)
        {
            /* if (ModelState.IsValid)
             {
                 _context.Add(car);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
*/
            if (ModelState.IsValid)
            {
                var car = new Car();
                car=_carService.MapToProductEntity(car, carViewModel);              

                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateDropdownLists();

            return View(carViewModel);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            /*  if (id == null)
              {
                  return NotFound();
              }

              var car = await _context.Cars.FindAsync(id);
              var carViewModel=_carService.MapToCarViewModel(car);
              if (car == null)
              {
                  return NotFound();
              }
              PopulateDropdownLists();
              return View(carViewModel);*/
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Brand)  // Include related data if necessary
                .Include(c => c.Modele) // Include related data if necessary
                .Include(c => c.Finition) // Include related data if necessary
                .Include(c => c.Year) // Include related data if necessary
                .FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            var carViewModel = _carService.MapToCarViewModel(car);

            PopulateDropdownLists();

            return View(carViewModel);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YearId,BrandId,ModelId,FinitionId,DateOfPurchase,PurchasePrice,Repair,RepairPrice,DateOfAvailabilityForSale,SellingPrice,DateOfSale")] CarViewModel carViewModel)
        {
            if (id != carViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var car = await _context.Cars.FindAsync(id);
                    if (car == null)
                    {
                        return NotFound();
                    }
                    car = _carService.MapToProductEntity(car, carViewModel);

                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(carViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateDropdownLists();

            return View(carViewModel);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Finition)
                .Include(c => c.Modele)
                .Include(c => c.Year)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
