using Microsoft.AspNetCore.Mvc;
using FleetManager.Domain.Entities;

namespace FleetManagerWebApp.Controllers
{
    public class FleetManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListAllVehicle()
        {
            return View();
        }

        public IActionResult GetDetail(string plate)
        {
            return View();
        }

        public IActionResult EditVehicle(string plate)
        {
            return View();
        }

        public IActionResult EditVehicle(string plate, Vehicle vehicle)
        {
            return View();
        }

        public IActionResult DeleteVehicle(Vehicle vehicle)
        {
            return View();
        }

        public IActionResult CreateVehicle(Vehicle vehicle)
        {
            return View();
        }


        public IActionResult AddVehicle(Vehicle vehicle)
        {
            return View();
        }






    }
}
