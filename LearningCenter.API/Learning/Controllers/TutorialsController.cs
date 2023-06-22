﻿using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using LearningCenter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
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
    public async Task<IEnumerable<ServiceResource>> GetAllAsync()
    {
        var services = await _serviceService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);

        return resources;

    }

    [HttpPost]
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