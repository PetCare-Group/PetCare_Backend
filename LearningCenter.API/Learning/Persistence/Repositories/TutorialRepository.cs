using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Shared.Persistence.Repositories;

public class ServiceRepository : BaseRepository, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _context.Services
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
    }

    public async Task<Service> FindByIdAsync(int serviceId)
    {
        return await _context.Services
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == serviceId);
        
    }

    // public async Task<Service> FindByTitleAsync(string title)
    // {
    //     return await _context.Services
    //         .Include(p => p.Category)
    //         .FirstOrDefaultAsync(p => p.Title == title);
    // }

    public async Task<IEnumerable<Service>> FindByCategoryIdAsync(int categoryId)
    {
        return await _context.Services
            .Where(p => p.UserId == categoryId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public void Update(Service service)
    {
        _context.Services.Update(service);
    }

    public void Remove(Service service)
    {
        _context.Services.Remove(service);
    }
}