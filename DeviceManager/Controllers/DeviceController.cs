using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManager.DTOModel;
using DeviceManager.DTOModel.Device;
using DeviceManager.EntityModel;
using DeviceManager.Repository;
using DeviceManager.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all devices with criterion.
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="200">Returns json with devices.</response> 
        /// <response code="400">Bad Request.</response>
        [HttpGet]
        public async Task<IActionResult> GetDeviceSearchCriterion([FromQuery] DeviceSearchCriterion deviceSearchCriterion)
        {
            try
            {
                var products = await _repository.GetDeviceWithCriterion(deviceSearchCriterion);
                var result = _mapper.Map<List<DeviceWithoutValuesDTO>>(products);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get a specific device.
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="200">Return json with device.</response> 
        /// <response code="400">Bad Request.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(int id)
        {
            try
            {
                var product = await _repository.GetDeviceById(id);
                var result = _mapper.Map<DeviceDTO>(product);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }


        /// <summary>
        /// Create or update a device.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     Create: Id is a required parameter
        ///     Update: Id is not a required parameter
        ///     POST /device
        ///     {
        ///         "id": 1,  
        ///         "name": "Dell",
        ///         "deviceTypeId": 1,
        ///         "DevicePropertyValues": {
        ///           "Value": "i3",
        ///           "DeviceTypePropertyId": 2 
        ///         }
        ///       }
        ///
        /// </remarks>
        /// <param object="device"></param>
        /// <returns>Returns empty json</returns>
        /// <response code="200">Device is succsefull created or updated.</response>
        /// <response code="400">Bad Request.</response> 
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateDevice([FromBody] CreateOrUpdateDeviceDTO device)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); //400
                }

                var createDev = _mapper.Map<Device>(device);

                if (device.Id != null)
                {
                    await _repository.UpdateDevice(createDev);
                }
                else
                {
                    await _repository.CreateDevice(createDev);
                }

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete a specific device.
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="204">Device is deleted.</response> 
        /// <response code="400">Bad Request.</response> 
        /// <response code="404">Not found device with this Id.</response> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            try
            {
                var exist = await _repository.Exist(id);
                if (!exist)
                {
                    return NotFound(); 
                }

                await _repository.DeleteDevice(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}