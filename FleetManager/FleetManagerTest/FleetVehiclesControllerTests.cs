using FakeItEasy;
using FleetManager.Application.Interfaces;
using FleetManager.Domain.Entities;
using FleetManagerWebApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagerTest
{
    public class FleetVehiclesControllerTests
    {

        private  FleetVehiclesController _fleetVehiclesController;
        private IFleetManagerRepository _fleetManager;
        private IHttpContextAccessor _httpContextAccessor;

        public FleetVehiclesControllerTests()
        {
            //Dependencies
            _fleetManager = A.Fake<IFleetManagerRepository>();  
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            //SUT
            _fleetVehiclesController = new FleetVehiclesController(_fleetManager);
        }

        //LIST
        [Fact]
        public void FleetVehiclesController_Index_ReturnsSuccess()
        {
            //Arrange - What do i need to bring in?
            var vehicles = A.Fake<IEnumerable<Vehicle>>();
            //Act
            var result = _fleetVehiclesController.Index();
            //Assert - Object check actions
            Assert.IsType<Task<IActionResult>>(result);
        }

        //CREATE
        [Fact]
        public void FleetVehiclesController_Create_ReturnsSuccess()
        {       
            //Act
            var result = _fleetVehiclesController.Create();
            //Assert - Object check actions
            Assert.IsType<ViewResult>(result);
        }

        //DELETE
        [Fact]
        public void FleetVehiclesController_Remove_ReturnsSuccess()
        {
            //Arrange - What do i need to bring in?
            var vehicle = A.Fake<Vehicle>();
            A.CallTo(_fleetManager.GetById(2)).Equals(vehicle);
            //Act
            var result = _fleetVehiclesController.Delete(2);
            //Assert - Object check actions
            Assert.IsType<Task<IActionResult>>(result);
        }



        //UPDATE
        [Fact]
        public async void FleetVehiclesController_Edit_ReturnsSuccess()
        {
            //Arrange - What do i need to bring in?
            var vehicle= A.Fake<Vehicle>();
            A.CallTo(await _fleetManager.GetById(1002)).Equals(vehicle);
            //Act
            var result = _fleetVehiclesController.Edit(1002);
            //Assert - Object check actions
            Assert.IsType<Task<IActionResult>>(result);
        }




    }
}
