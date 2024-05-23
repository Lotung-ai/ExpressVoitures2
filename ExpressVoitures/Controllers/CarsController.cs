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

namespace ExpressVoitures.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBrandRepository _brandRepository;
        private readonly IModeleRepository _modeleRepository;
        private readonly IFinitionRepository _finitionRepository;
        private readonly IYearRepository _yearRepository;

        public CarsController(ApplicationDbContext context, IBrandRepository brandRepository,IModeleRepository modeleRepository, IFinitionRepository finitionRepository, IYearRepository yearRepository)
        {
            _context = context;
            _brandRepository= brandRepository;
            _modeleRepository= modeleRepository;
            _finitionRepository= finitionRepository;
            _yearRepository= yearRepository;
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
            /*var brandsData = _brandRepository.GetBrands();
            var carViewModel = new CarViewModel();
            carViewModel.Brands = new List<SelectListItem>();
            foreach (var brand in brandsData)
            {
                carViewModel.Brands.Add(new SelectListItem { Text = brand.Text, Value = brand.Value });
            }
            */
             return View();
           /* var viewModel = new CarViewModel
            {
                Brands = new SelectList(_brandRepository.GetBrands(), "Value", "Text"),
                Finitions = new SelectList(_finitionRepository.GetFinitions(), "Value", "Text"),
                Models = new SelectList(_modeleRepository.GetModels(), "Value", "Text"),
                Years = new SelectList(_yearRepository.GetYears(), "Value", "Text")
            };

            return View(viewModel);*/
            
            
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

          //  ViewData["ModelId"] = _modeleRepository.GetModels();

            ViewData["YearId"] = _yearRepository.GetYears();
        }
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
             ViewData["BrandId"] = _brandRepository.GetBrands();

             ViewData["FinitionId"] = _finitionRepository.GetFinitions();

             ViewData["ModelId"] = _modeleRepository.GetModels();

             ViewData["YearId"] = _yearRepository.GetYears();
             return View(car);*/
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    YearId = carViewModel.YearId,               
                    BrandId = carViewModel.BrandId,
                    ModelId = carViewModel.ModelId,
                    FinitionId = carViewModel.FinitionId,
                    DateOfPurchase = carViewModel.DateOfPurchase,
                    PurchasePrice = carViewModel.PurchasePrice,
                    Repair = carViewModel.Repair,
                    RepairPrice = carViewModel.RepairPrice,
                    DateOfAvailabilityForSale = carViewModel.DateOfAvailabilityForSale,
                    SellingPrice = carViewModel.SellingPrice,
                    DateOfSale = carViewModel.DateOfSale
                };

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
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            PopulateDropdownLists();
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YearId,BrandId,ModelId,FinitionId,DateOfPurchase,PurchasePrice,Repair,RepairPrice,DateOfAvailabilityForSale,SellingPrice,DateOfSale")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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

            return View(car);
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
