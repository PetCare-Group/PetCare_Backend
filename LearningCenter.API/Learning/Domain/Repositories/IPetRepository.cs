using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> ListAsync();
    Task AddAsync(Pet category);
    Task<Pet> FindByNameAsync(string name);
    void Update(Pet pet);
    void Remove(Pet pet);
}