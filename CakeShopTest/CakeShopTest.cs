using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CakeShop.BL.Interfaces;
using CakeShop.BL.Services;
using CakeShop.DL.Interfaces;
using CakeShop.Models.Models;

namespace CakeShop.Test
{
    public class CakeServiceTest
    {
        private Mock<ICakeRepository> _cakeRepository;

        private IList<Cake> Cakes = new List<Cake>()
        {
            new Cake()
            {
                Id = Guid.NewGuid(),
                CakeName = "Chocolate Cake",
                Price = 10.99m,
                CakeDescription = "Delicious cake"
            },
            new Cake()
            {
                Id = Guid.NewGuid(),
                CakeName = "Vanilla Cake",
                Price = 15.99m,
                CakeDescription = "Yummy cake"
            }
        };

        public CakeServiceTest()
        {
            _cakeRepository = new Mock<ICakeRepository>();
        }

        [Fact]
        public async Task Cake_GetAll_Count()
        {
            var expectedCount = 2;

            _cakeRepository.Setup(x => x.GetAllCakes()).Returns(Task.FromResult(Cakes.AsEnumerable()));

            var service = new CakeService(_cakeRepository.Object);

            var result = await service.GetAllCakes();

            var cakes = result.ToList();
            Assert.NotNull(cakes);
            Assert.Equal(expectedCount, cakes.Count());
            Assert.Equal(Cakes, cakes);
        }

        [Fact]
        public async Task Cake_GetById_Ok()
        {
            var cakeId = Cakes.First().Id;
            var expectedCake = Cakes.FirstOrDefault(x => x.Id == cakeId);
            var expectedCakeName = $"!{expectedCake.CakeName}";

            _cakeRepository.Setup(x => x.GetCakeById(cakeId)).Returns(Task.FromResult(Cakes.FirstOrDefault(x => x.Id == cakeId)));
            var service = new CakeService(_cakeRepository.Object);

            var result = await service.GetCakeById(cakeId);

            Assert.NotNull(result);
            Assert.Equal(expectedCake, result);
            Assert.Equal(expectedCakeName, result?.CakeName);
        }

        [Fact]
        public async Task Cake_GetById_Not_Found()
        {
            var cakeId = Guid.NewGuid();

            _cakeRepository.Setup(x => x.GetCakeById(cakeId)).Returns(Task.FromResult(Cakes.FirstOrDefault(x => x.Id == cakeId)));

            var service = new CakeService(_cakeRepository.Object);

            var result = await service.GetCakeById(cakeId);

            Assert.Null(result);
        }

        [Fact]
        public async Task Cake_Add_Ok()
        {
            var cakeToAdd = new Cake()
            {
                Id = Guid.NewGuid(),
                CakeName = "New Cake",
                Price = 12.99m,
                CakeDescription = "Freshly baked cake"
            };
            var expectedCakeCount = 3;

            _cakeRepository.Setup(x => x.AddCake(It.IsAny<Cake>())).Callback(() =>
            {
                Cakes.Add(cakeToAdd);
            }).Returns(Task.CompletedTask);

            var service = new CakeService(_cakeRepository.Object);

            await service.AddCake(cakeToAdd);

            Assert.Equal(expectedCakeCount, Cakes.Count);
            Assert.Equal(cakeToAdd, Cakes.LastOrDefault());
        }

        [Fact]
        public async Task Cake_Update_Ok()
        {
            var cakeToUpdate = Cakes.First();
            cakeToUpdate.CakeName = "Updated Cake";

            _cakeRepository.Setup(x => x.UpdateCake(cakeToUpdate)).Returns(Task.CompletedTask);

            var service = new CakeService(_cakeRepository.Object);

            await service.UpdateCake(cakeToUpdate);

            Assert.Equal("Updated Cake", Cakes.First().CakeName);
        }

        [Fact]
        public async Task Cake_Delete_Ok()
        {
            var cakeToDelete = Cakes.First();
            var expectedCakeCount = 1;

            _cakeRepository.Setup(x => x.DeleteCake(cakeToDelete.Id)).Returns(Task.CompletedTask);

            var service = new CakeService(_cakeRepository.Object);

            await service.DeleteCake(cakeToDelete.Id);

            Assert.Equal(expectedCakeCount, Cakes.Count);
            Assert.DoesNotContain(cakeToDelete, Cakes);
        }
    }
}