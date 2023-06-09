using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class PetRepository : BaseRepository ,IPetRepository
{
    public PetRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Pet>> ListAsync()
    {
        return await _context.Pets.ToListAsync();
    }

    public async Task AddAsync(Pet pet)
    {

        await _context.Pets.AddAsync(pet);
    }

    public async Task<Pet> FindByNameAsync(string name)
    {
        return await _context.Pets.SingleOrDefaultAsync(x => x.Name == name);
    }

    public void Update(Pet pet)
    {
        _context.Pets.Update(pet);
    }

    public void Remove(Pet pet)
    {
        _context.Pets.Remove(pet);
    }
}