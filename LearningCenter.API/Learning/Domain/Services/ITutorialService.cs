using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IServiceService
{
    Task<IEnumerable<Service>> ListAsync();
    // Task<IEnumerable<Service>> ListByCategoryIdAsync(int categoryId);
    Task<ServiceResponse> SaveAsync(Service service);
    // Task<ServiceResponse> UpdateAsync(int serviceId, Service service);
    // Task<ServiceResponse> DeleteAsync(int serviceId);
}