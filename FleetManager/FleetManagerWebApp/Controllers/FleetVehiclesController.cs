using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetManager.Domain.Entities;
using FleetManager.Application.Interfaces;

namespace FleetManagerWebApp.Controllers
{
    public class FleetVehiclesController : Controller
    {
        readonly IFleetManagerRepository _fleetManager;

        public FleetVehiclesController(IFleetManagerRepository fleetManager)
        {
            this._fleetManager = fleetManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _fleetManager.GetAll());
        }


        // GET: FleetVehicles/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,NumberOfPassengers,Color")] Vehicle vehicle)
        {
            bool result = await _fleetManager.Add(vehicle);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _fleetManager.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,NumberOfPassengers,Color")] Vehicle vehicle)
        {

            try
            {
                _fleetManager.Update(vehicle);
            }
            catch (DbUpdateConcurrencyException)
            { }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _fleetManager.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _fleetManager.GetById(id);
            if (vehicle != null)
            {
                _fleetManager.Delete(vehicle);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
