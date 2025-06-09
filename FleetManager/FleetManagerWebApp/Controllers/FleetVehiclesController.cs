using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetManager.Domain.Entities;
using FleetManager.Application.Interfaces;
using FleetManager.Domain.ViewData;
using FleetManager.Application.Ultility;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        public IActionResult Create()
        {
            ViewBag.VehiclesType = EnumExtensionTypevehicle.GetListEnum(); 

            return View(); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,_Type,NumberOfPassengers,Color,Number,Series")] ViewVehicle viewVehicle)
        {
            Vehicle vehicle = ViewVehicleParser.ParseToVehicle(viewVehicle);

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

            ViewVehicle viewVehicle = ViewVehicleParser.ParseFromVehicle(vehicle);
            ViewBag.VehiclesType = EnumExtensionTypevehicle.GetListEnum();

            return View(viewVehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,_Type,NumberOfPassengers,Color,Series,Number")] ViewVehicle viewVehicle)
        {
            var vehicle = ViewVehicleParser.ParseToVehicle(viewVehicle);

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
            var vehicleView = ViewVehicleParser.ParseFromVehicle(vehicle);

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



static public class EnumExtensionTypevehicle
{
    public static List<SelectListItem> GetListEnum()
    {
        return Enum.GetValues(typeof(TypeVehicle))
               .Cast<TypeVehicle>()
               .Select(e => new SelectListItem
               {
                   Value = e.ToString(),
                   Text = e.ToString()
               })
               .ToList();
    }

}