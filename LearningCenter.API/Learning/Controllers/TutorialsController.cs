using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using LearningCenter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create and read information about people who gives services")]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public ServicesController(IServiceService serviceService, IMapper mapper)
    {
        _serviceService = serviceService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "See services",
        Description = "See all the information about the users that gives services") 
    ]
    [ProducesResponseType(typeof(IEnumerable<PetResource>), 200)]
    public async Task<IEnumerable<ServiceResource>> GetAllAsync()
    {
        var services = await _serviceService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);

        return resources;

    }

     [HttpGet("{id}")]
     [SwaggerOperation(
         Summary = "See a service",
         Description = "See a specified information about a person who gives services by its Id") 
     ]
     [ProducesResponseType(typeof(IEnumerable<ServiceResource>), 200)]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _serviceService.GetByIdAsync(id);
        var resource = _mapper.Map<Service, ServiceResource>(user);
        return Ok(resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Save a new service",
        Description = "Add a new person who gives services sending all the information about it") 
    ]
    [ProducesResponseType(typeof(ServiceResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveServiceResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var service = _mapper.Map<SaveServiceResource, Service>(resource);

        var result = await _serviceService.SaveAsync(service);

        if (!result.Success)
            return BadRequest(result.Message);

        var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);

        return Ok(serviceResource);
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutAsync(int id, [FromBody] SaveServiceResource resource)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState.GetErrorMessages());

    //     var service = _mapper.Map<SaveServiceResource, Service>(resource);

    //     var result = await _serviceService.UpdateAsync(id, service);

    //     if (!result.Success)
    //         return BadRequest(result.Message);

    //     var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);

    //     return Ok(serviceResource);
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteAsync(int id)
    // {
    //     var result = await _serviceService.DeleteAsync(id);
        
    //     if (!result.Success)
    //         return BadRequest(result.Message);

    //     var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);

    //     return Ok(serviceResource);
    // }

}