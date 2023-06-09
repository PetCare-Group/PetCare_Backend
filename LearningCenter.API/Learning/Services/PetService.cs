// using LearningCenter.API.Learning.Domain.Model;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class PetService: IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;


    public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork)
    {
        _petRepository = petRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Pet>> ListByClientAsync()
    {
        return await _petRepository.ListAsync();
    }

    public async Task<PetResponse> DeletePetAsync(string name)
    {
        var existingPet = await _petRepository.FindByNameAsync(name);
        if (existingPet == null)
            return new PetResponse("error mascota no encontrada");

        try
        {
            _petRepository.Update(existingPet);
            await _unitOfWork.CompleteAsync();

            return new PetResponse(existingPet);
        }
        catch (Exception e)
        {
            return new PetResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<PetResponse> UpdatePetAsync(string name, Pet pet)
    {
        var existingPet = await _petRepository.FindByNameAsync(name);

        if (existingPet == null)
        {
            return new PetResponse("Pet not found");
        }

        existingPet.Name = pet.Name;
        existingPet.Description = pet.Description;
        existingPet.Castrado = pet.Castrado;
        try
        {
            _petRepository.Update(existingPet);
            await _unitOfWork.CompleteAsync();
            return new PetResponse(existingPet);
        }
        catch (Exception e)
        {
            return new PetResponse($"un error ha ocurrido en la base de datos: {e.Message} ");
        }
    }

    public Task<PetResponse> FindPetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<PetResponse> SavePetAsync(Pet pet)
    {
        try
        {
            await _petRepository.AddAsync(pet);
            await _unitOfWork.CompleteAsync();
            return new PetResponse(pet);
        }
        catch (Exception e)
        {
            return new PetResponse($"un error ha ocurrido en la base de datos: {e.Message} ");
        }
    }
}