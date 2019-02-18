using AutoMapper;
using DeviceManager.Controllers;
using DeviceManager.DTOModel.Device;
using DeviceManager.DTOModel.DeviceType;
using DeviceManager.Repository;
using DeviceManager.Utility;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DeviceManager.Tests
{
    public class DeviceUnitTest
    {
        [Fact]
        public async void TestGetDeviceById()
        {
            var mockRepository = new Mock<IDeviceRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceController = new DeviceController(mockRepository.Object, mockMapper.Object);

            var result = await deviceController.GetDeviceById(1);

            var x = result as OkObjectResult;

            Assert.Equal(200, x.StatusCode);
        }

        [Fact]
        public async Task Test_Create_Device()
        {
            var device = new CreateOrUpdateDeviceDTO
            {
                Name = "Testing Device",
                DeviceTypeId = 100
            };

            var mockRepository = new Mock<IDeviceRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceController = new DeviceController(mockRepository.Object, mockMapper.Object);

            var actionResult = await deviceController.CreateOrUpdateDevice(device);

            var x = actionResult as OkResult;

            Assert.Equal(200, x.StatusCode);
        }

        [Fact]
        public async Task Test_Update_Device()
        {
            var device = new CreateOrUpdateDeviceDTO
            {
                Id = 1,
                Name = "Testing Device",
                DeviceTypeId = 100
            };

            var mockRepository = new Mock<IDeviceRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceController = new DeviceController(mockRepository.Object, mockMapper.Object);

            var actionResult = await deviceController.CreateOrUpdateDevice(device);

            var x = actionResult as OkResult;

            Assert.Equal(200, x.StatusCode);
        }

        [Fact]
        public async Task Test_Try_To_Create_Null_Device()
        {
            CreateOrUpdateDeviceDTO device = null;

            var mockRepository = new Mock<IDeviceRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceController = new DeviceController(mockRepository.Object, mockMapper.Object);

            var actionResult = await deviceController.CreateOrUpdateDevice(device) as BadRequestObjectResult;

            Assert.Equal(400, actionResult.StatusCode);
        }

        [Fact]
        public async void TestDeleteDevice()
        {
            var mockRepository = new Mock<IDeviceRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceController = new DeviceController(mockRepository.Object, mockMapper.Object);

            var result = await deviceController.DeleteDevice(1);
            
            var x = result as NotFoundResult;

            Assert.Equal(404, x.StatusCode);
        }

        [Fact]
        public async void TestGetDeviceSearchCriterion()
        {
            var device = new DeviceSearchCriterion
            {
                Name = "Laptop"
            };
            var mockRepository = new Mock<IDeviceRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceController = new DeviceController(mockRepository.Object, mockMapper.Object);

            var result = await deviceController.GetDeviceSearchCriterion(device);

            var x = result as OkObjectResult;

            Assert.Equal(200, x.StatusCode);
        }
    }
}
