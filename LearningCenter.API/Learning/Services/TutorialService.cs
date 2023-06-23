using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _serviceRepository = serviceRepository;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<Service> GetByIdAsync(int id)
    {
         var user = await _serviceRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("Service not found");
        return user;
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _serviceRepository.ListAsync();
    }

    // public async Task<IEnumerable<Service>> ListByCategoryIdAsync(int categoryId)
    // {
    //     return await _serviceRepository.FindByCategoryIdAsync(categoryId);
    // }

    public async Task<ServiceResponse> SaveAsync(Service service)
    {
        // Validate CategoryId

        var existingCategory = await _categoryRepository.FindByIdAsync(service.UserId);

        if (existingCategory == null)
            return new ServiceResponse("Invalid Category");
        
        // Validate Title

        // var existingServiceWithTitle = await _serviceRepository.FindByTitleAsync(service.Title);

        // if (existingServiceWithTitle != null)
        //     return new ServiceResponse("Service title already exists.");

        try
        {
            // Add Service
            await _serviceRepository.AddAsync(service);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new ServiceResponse(service);

        }
        catch (Exception e)
        {
            // Error Handling
            return new ServiceResponse($"An error occurred while saving the service: {e.Message}");
        }

        
    }

    // public async Task<ServiceResponse> UpdateAsync(int serviceId, Service service)
    // {
    //     var existingService = await _serviceRepository.FindByIdAsync(serviceId);
        
    //     // Validate Service

    //     if (existingService == null)
    //         return new ServiceResponse("Service not found.");

    //     // Validate CategoryId

    //     var existingCategory = await _categoryRepository.FindByIdAsync(service.CategoryId);

    //     if (existingCategory == null)
    //         return new ServiceResponse("Invalid Category");
        
    //     // Validate Title

    //     var existingServiceWithTitle = await _serviceRepository.FindByTitleAsync(service.Title);

    //     if (existingServiceWithTitle != null && existingServiceWithTitle.Id != existingService.Id)
    //         return new ServiceResponse("Service title already exists.");
        
    //     // Modify Fields
    //     existingService.Title = service.Title;
    //     existingService.Description = service.Description;

    //     try
    //     {
    //         _serviceRepository.Update(existingService);
    //         await _unitOfWork.CompleteAsync();

    //         return new ServiceResponse(existingService);
            
    //     }
    //     catch (Exception e)
    //     {
    //         // Error Handling
    //         return new ServiceResponse($"An error occurred while updating the service: {e.Message}");
    //     }

    // }

    // public async Task<ServiceResponse> DeleteAsync(int serviceId)
    // {
    //     var existingService = await _serviceRepository.FindByIdAsync(serviceId);
        
    //     // Validate Service

    //     if (existingService == null)
    //         return new ServiceResponse("Service not found.");
        
    //     try
    //     {
    //         _serviceRepository.Remove(existingService);
    //         await _unitOfWork.CompleteAsync();

    //         return new ServiceResponse(existingService);
            
    //     }
    //     catch (Exception e)
    //     {
    //         // Error Handling
    //         return new ServiceResponse($"An error occurred while deleting the service: {e.Message}");
    //     }

    // }
}