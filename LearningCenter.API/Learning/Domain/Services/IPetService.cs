using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IPetService
{
    Task<IEnumerable<Pet>> ListByClientAsync();
    Task <PetResponse> DeletePetAsync(string name);
    Task<PetResponse> UpdatePetAsync(string name, Pet pet);
    Task<PetResponse> FindPetByNameAsync(string name);
    Task<PetResponse> SavePetAsync(Pet pet);
    
}