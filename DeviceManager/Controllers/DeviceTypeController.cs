using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManager.DTOModel;
using DeviceManager.DTOModel.DeviceType;
using DeviceManager.EntityModel;
using DeviceManager.Repository;
using DeviceManager.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTypeController : ControllerBase
    {
        private readonly IDeviceTypeRepository _repository;
        private readonly IMapper _mapper;

        public DeviceTypeController(IDeviceTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all device type.
        /// </summary>
        /// <param name=""></param> 
        /// <response code="200">Returns json with devices.</response> 
        /// <response code="400">Bad Request.</response>
        [HttpGet]
        public async Task<IActionResult> GetDeviceType()
        {
            try
            {
                var result = await _repository.GetDeviceType();
                var devices = _mapper.Map<List<DeviceTypeDTO>>(result);
                return Ok(devices);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get a specific device type.
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="200">Returns json with device.</response> 
        /// <response code="400">Bad Request.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneDeviceType(int id)
        {
            try
            {
                var result = await _repository.GetDeviceTypeById(id);
                var devices = _mapper.Map<DeviceTypeDTO>(result);
                return Ok(devices);  
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
        ///         "Name": "Racunar",
        ///         "DeviceTypeProperties": [
        ///             {
        ///                 "Name": "Operativni sistem"
        ///             },
        ///             {
        ///                 "Name": "Procesor"
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <param object="deviceTypeDTO"></param>
        /// <returns>Returns empty json</returns>
        /// <response code="200">Device type is succsefull created or updated.</response>
        /// <response code="400">Bad Request.</response>
        [HttpPost]
        public async Task<IActionResult> CreateDeviceType([FromBody] CreateOrUpdateDeviceTypeDTO deviceTypeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var deviceTypeEntity = _mapper.Map<DeviceType>(deviceTypeDTO);
                if(deviceTypeDTO.Id != null)
                {
                    await _repository.UpdateDeviceType(deviceTypeEntity);
                }
                else
                {
                    await _repository.CreateDeviceType(deviceTypeEntity);
                    
                }
                return Ok();
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            
        }

        /// <summary>
        /// Delete a specific device type.
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="204">Device type is deleted.</response> 
        /// <response code="400">Bad Request.</response> 
        /// <response code="404">Not found device type with this Id.</response> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceType(int id)
        {
            try
            {
                var exist = await _repository.Exist(id);
                if (!exist)
                {
                    return NotFound(); 
                }

                await _repository.DeleteDeviceType(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}