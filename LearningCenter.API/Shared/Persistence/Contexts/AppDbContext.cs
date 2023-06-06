using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tutorial> Tutorials { get; set; }
    
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Pet> Pets { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Pets

        builder.Entity<Pet>().ToTable("Pets");
        builder.Entity<Pet>().HasKey(p => p.Id);
        builder.Entity<Pet>().Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Entity<Pet>().Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Entity<Pet>().Property(p => p.Description).IsRequired();
        builder.Entity<Pet>().Property(p => p.UserId).IsRequired();
        builder.Entity<Pet>().Property(p => p.Castrado).IsRequired();

        // builder.Entity<Pet>().HasOne(p => p.User).WithMany(c => c.mascotas).HasForeignKey(p => p.UserId);



        //Categories

        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        
        // Relationships
        builder.Entity<User>()
            .HasOne(p => p.Tutorial)
            .WithOne(p => p.User);
            // .HasForeignKey(p => p.);
        
        builder.Entity<Tutorial>().ToTable("Tutorials");
        builder.Entity<Tutorial>().HasKey(p => p.Id);
        builder.Entity<Tutorial>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //builder.Entity<Tutorial>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Tutorial>().Property(p => p.Description).HasMaxLength(120);
        
        // Users
            
        // Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        

    

        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}