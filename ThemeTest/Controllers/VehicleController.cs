using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThemeTest.DB;
using ThemeTest.Models.Vehicles;
using ThemeTest.Services.Interface;

namespace ThemeTest.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            return View(vehicles);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: /Vehicles/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleCreateDto vehicle)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.CreateAsync(vehicle);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: /Vehicles/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var vehicle = await _vehicleService.GetAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: /Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, VehicleUpdateDto vehicle)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehicleService.UpdateAsync(id,vehicle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await VehicleExists(id))
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
            return View(vehicle);
        }

        // GET: /Vehicles/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var vehicle = await _vehicleService.GetAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: /Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _vehicleService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        private async Task<bool> VehicleExists(Guid id)
        {
            return await _vehicleService.GetAsync(id) != null;
        }


    }
}
