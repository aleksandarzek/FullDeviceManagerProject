using AutoMapper;
using DeviceManager.Controllers;
using DeviceManager.DTOModel.Device;
using DeviceManager.DTOModel.DeviceType;
using DeviceManager.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DeviceManager.Tests
{
    public class DeviceTypeUnitTest
    {
        [Fact]
        public async void TestGetDeviceTypeById()
        {
            var mockRepository = new Mock<IDeviceTypeRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceTypeController = new DeviceTypeController(mockRepository.Object, mockMapper.Object);

            var result = await deviceTypeController.GetOneDeviceType(1);

            var x = result as OkObjectResult;

            Assert.Equal(200, x.StatusCode);
        }

        [Fact]
        public async Task Test_Create_Device()
        {
            var device = new CreateOrUpdateDeviceTypeDTO
            {
                Name = "Testing Device Type"
            };

            var mockRepository = new Mock<IDeviceTypeRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceTypeController = new DeviceTypeController(mockRepository.Object, mockMapper.Object);

            var actionResult = await deviceTypeController.CreateDeviceType(device);

            var x = actionResult as OkResult;

            Assert.Equal(200, x.StatusCode);
        }

        [Fact]
        public async Task Test_Update_Device()
        {
            var device = new CreateOrUpdateDeviceTypeDTO
            {
                Id = 1,
                Name = "Testing Device"
            };

            var mockRepository = new Mock<IDeviceTypeRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceTypeController = new DeviceTypeController(mockRepository.Object, mockMapper.Object);

            var actionResult = await deviceTypeController.CreateDeviceType(device);

            var x = actionResult as OkResult;

            Assert.Equal(200, x.StatusCode);
        }

        [Fact]
        public async Task Test_Try_To_Create_Null_Device()
        {
            CreateOrUpdateDeviceTypeDTO device = null;

            var mockRepository = new Mock<IDeviceTypeRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceTypeController = new DeviceTypeController(mockRepository.Object, mockMapper.Object);

            var actionResult = await deviceTypeController.CreateDeviceType(device) as BadRequestObjectResult;

            Assert.Equal(400, actionResult.StatusCode);
        }

        [Fact]
        public async void TestDeleteDevice()
        {
            var mockRepository = new Mock<IDeviceTypeRepository>();
            var mockMapper = new Mock<IMapper>();

            var deviceTypeController = new DeviceTypeController(mockRepository.Object, mockMapper.Object);

            var result = await deviceTypeController.DeleteDeviceType(1);

            var x = result as NotFoundResult;

            Assert.Equal(404, x.StatusCode);
        }
    }
}
