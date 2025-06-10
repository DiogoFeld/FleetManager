using FleetManager.Domain.Entities;
using FleetManager.Infrastructure.Data;
using FleetManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerTest
{
    public class FleetManagerRepositoryTests
    {
        private async Task<FleetDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<FleetDbContext>()
                .UseInMemoryDatabase("FleetManager")
                .Options;
            var databaseContext = new FleetDbContext(options);
            databaseContext.Database.EnsureCreated();


                databaseContext.Vehicles.Add(
                  new Vehicle()
                  {
                      Id = 1,
                      ChassisId = new ChassisId()
                      {
                          Number = 125165161,
                          Series = "somethingPlate"
                      },
                      NumberOfPassengers = 2,
                      _Type = TypeVehicle.Bus,
                      Color = "red"
                  });
         
                await databaseContext.SaveChangesAsync();

            return databaseContext;
        }


        [Fact]
        public async void FleetRepository_Add_ReturnsBool()
        {
            //Arrange
            var vehicle = new Vehicle()
            {
                Id = 10,
                ChassisId = new ChassisId()
                {
                    Number = 134897,
                    Series = "AnotherPLate"
                },
                NumberOfPassengers = 1,
                _Type = TypeVehicle.Car,
                Color = "blue"
            };

            var dbContext = await GetDbContext();
            var vehicleRepository = new FleetManagerRepository(dbContext);

            //Act
            var result = await vehicleRepository.Add(vehicle);

            //Assert
            Assert.True(result);
        }


        [Fact]
        public async void FleetRepository_Update_ReturnsBool()
        {
            //Arrange
            var vehicle = new Vehicle()
            {
                Id = 1,
                ChassisId = new ChassisId()
                {
                    Number = 25246,
                    Series = "YetAnotherPLate"
                },
                NumberOfPassengers = 1,
                _Type = TypeVehicle.Car,
                Color = "black"
            };

            var dbContext = await GetDbContext();
            var vehicleRepository = new FleetManagerRepository(dbContext);

            //Act
            var result = await vehicleRepository.Update(vehicle);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async void FleetRepository_Delete_ReturnsBool()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var vehicleRepository = new FleetManagerRepository(dbContext);

            var v = await vehicleRepository.GetAll();
            var vehicle = await vehicleRepository.GetById(1);

            //Act
            var result = await vehicleRepository.Delete(vehicle);

            //Assert
            Assert.True(result);
        }


    }
}
