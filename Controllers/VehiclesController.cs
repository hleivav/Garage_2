using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2.Data;
using Garage_2.Models;
using Garage_2.Models.ViewModels;

namespace Garage_2.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage_2Context _context;

        public VehiclesController(Garage_2Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Filter(string RegNo/*, int? vehicleType, string color*/)
        {
            var model = string.IsNullOrWhiteSpace(RegNo) ?
                                    _context.Vehicles :
                                    _context.Vehicles.Where(m => m.RegNo!.StartsWith(RegNo));

            //model = vehicleType == null ?
            //                 model :
            //                 model.Where(m => (int)m.VehicleType == vehicleType);

            //model = color == null ?
            //                 model :
            //                 model.Where(m => m.Color.Equals(color));

            return View(nameof(Index), await model.ToListAsync());
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles?.ToListAsync());
        }

        // GET: Vehicles
        public async Task<IActionResult> Overview()
        {
            var model = _context.Vehicles.Select(v => new OverviewViewModel
            {
                Id = v.Id,
                RegNo = v.RegNo,
                VehicleType = v.VehicleType,
                PartkingStartAt = v.PartkingStartAt
            });

            return _context.Vehicles != null ?
                        View("VehicleOverview", await model.ToListAsync()) :
                        Problem("Entity set 'Garage_2Context.Vehicles'  is null.");
        }

        //public async Task<IActionResult> Receipt(int? id)
        //{
        //    var model = _context.Vehicles.Select(v => new ReceiptViewModel
        //    {
        //        Id = v.Id,
        //        RegNo = v.RegNo,
        //        PartkingStartAt = v.PartkingStartAt,
        //    });

        //    return _context.Vehicles != null ?
        //                View("VehicleOverview", await model.ToListAsync()) :
        //                Problem("Entity set 'Garage_2Context.Vehicles'  is null.");
        //}

        public async Task<IActionResult> VehicleReceipt(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }


            //Ta bort fordonet ur databasen
            var parkedTime = DateTime.Now.Subtract(vehicles.PartkingStartAt);
            var totalCost = parkedTime.TotalHours * 40;

            //Skapa en model med den datan som ska presenteras i vyn
            var model = new ReceiptViewModel
            {
                RegNo = vehicles.RegNo,
                PartkingStartAt = vehicles.PartkingStartAt,
                ParkedTime = DateTime.Now.Subtract(vehicles.PartkingStartAt),
                TotalCost = totalCost,
            };

            _context.Vehicles.Remove(vehicles);
            await _context.SaveChangesAsync();

            TempData["deleteMessage"] = "Fordonet har parkerats korrekt";

            return View("View", model);
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegNo,VehicleType,Color,Make,Model,NoOfWheels")] Vehicles vehicles)
        {

            if (ModelState.IsValid)
            {
                vehicles.PartkingStartAt = DateTime.Now;
                _context.Add(vehicles);
                await _context.SaveChangesAsync();
                TempData["saveMessage"] = "Fordonet har parkerats";////////TEMP//////////////////
                return RedirectToAction(nameof(Index));
            }
            return View(vehicles);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }

            //-------------
            var model = new VehicleEditViewModel
            {
                Id = vehicles.Id,
                RegNo = vehicles.RegNo,
                VehicleType = vehicles.VehicleType, 
                Color = vehicles.Color,
                Make = vehicles.Make,
                Model = vehicles.Model,
                NoOfWheels = vehicles.NoOfWheels
            };
            return View(model);
        }

        [AcceptVerbs("GET")]
        public async Task<IActionResult> CheckRegNo(string RegNo)
        {
            if (string.IsNullOrWhiteSpace(RegNo) || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles.FirstOrDefaultAsync(v => v.RegNo == RegNo);
            if (vehicles == null)
            {
                return Json(true);
            }
            return Json(false);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] // testade att ta bort den här men den verkar inte validera om fordonet finns.//////////
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegNo,VehicleType,Color,Make,Model,NoOfWheels")] VehicleEditViewModel viewmodel)
        {
            if (id != viewmodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //------------
                    var vehicle = new VehicleEditViewModel
                    {
                        Id=viewmodel.Id,
                        RegNo = viewmodel.RegNo,
                        VehicleType = viewmodel.VehicleType,
                        Color = viewmodel.Color,
                        Make = viewmodel.Make,
                        Model = viewmodel.Model,
                        NoOfWheels = viewmodel.NoOfWheels
                    };
                    _context.Update(vehicle);
                    _context.Entry(vehicle).Property(v => v.PartkingStartAt).IsModified = false;
                    _context.Entry(vehicle).Property(v => v.RegNo).IsModified = false;
                    await _context.SaveChangesAsync();
                    //TempData////////////////////////////////////////////////////////////////
                    TempData["editMessage"] = "Ändringarna har genomförts";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclesExists(viewmodel.Id))
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
            return View(viewmodel);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'Garage_2Context.Vehicles'  is null.");
            }
            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles != null)
            {
                _context.Vehicles.Remove(vehicles);
            }



            await _context.SaveChangesAsync();

            TempData["deleteMessage"] = "Fordonet har parkerats korrekt";
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclesExists(int id)
        {
            return (_context.Vehicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
