using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/categories/{categoryId}/services")]
public class CategoryServicesController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public CategoryServicesController(IServiceService serviceService, IMapper mapper)
    {
        _serviceService = serviceService;
        _mapper = mapper;
    }

    // [HttpGet]
    // public async Task<IEnumerable<ServiceResource>> GetAllByCategoryIdAsync(int categoryId)
    // {
    //     var services = await _serviceService.ListByCategoryIdAsync(categoryId);

    //     var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);

    //     return resources;
    // }
}