using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using LearningCenter.API.Shared.Extensions;

namespace LearningCenter.API.Learning.Controller;

[ApiController]

[Route("/api/v1/[controller]")]
public class PetController: ControllerBase
{
    
    private readonly IPetService _petService;
    private readonly IMapper _mapper;

    public PetController(IPetService petService, IMapper mapper)
    {
       
        _petService = petService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PetResource>> GetAllAsync()
    {
        
        var pets = await _petService.ListByClientAsync();
        var resources = _mapper.Map<IEnumerable<Pet>, IEnumerable<PetResource>>(pets);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePetResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var pet = _mapper.Map<SavePetResource, Pet>(resource);

        var result = await _petService.SavePetAsync(pet);

        if (!result.Success)
            return BadRequest(result.Message);

        var petResource = _mapper.Map<Pet, PetResource>(result.Resource);

        return Ok(petResource);
    }

    [HttpPut("{name}")]
    public async Task<IActionResult> PutAsync(string name, [FromBody] SavePetResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var pet = _mapper.Map<SavePetResource, Pet>(resource);
        var result = await _petService.UpdatePetAsync(name, pet);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var petResource = _mapper.Map<Pet, PetResource>(result.Resource);

        return Ok(petResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string name)
    {
        var result = await _petService.DeletePetAsync(name);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var petResource = _mapper.Map<Pet, PetResource>(result.Resource);

        return Ok(petResource);
    }
    
}
