using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IPetService
{
    Task<IEnumerable<Pet>> ListByClientAsync();
    Task <PetResponse> DeletePetAsync(int id);
    Task<PetResponse> UpdatePetAsync(int id, Pet pet);
    Task<PetResponse> FindPetByNameAsync(string name);
    Task<PetResponse> SavePetAsync(Pet pet);
    
}