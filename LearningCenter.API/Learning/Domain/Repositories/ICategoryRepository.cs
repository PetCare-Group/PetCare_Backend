using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> ListAsync();
    Task AddAsync(Category category);
    Task<User> FindByIdAsync(int id);
    void Update(Category category);
    void Remove(Category category);

}