using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Service> Services { get; set; }
    
    public DbSet<User> Users { get; set; }

    public DbSet<Payment>Payments { get; set; }

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

        //Payments
        builder.Entity<Payment>().ToTable("Payments");
        builder.Entity<Payment>().HasKey(p=>p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.Number).IsRequired().HasMaxLength(16);
    
    builder.Entity<Payment>().HasOne(p=>p.User).WithMany(p=>p.Payments);
        
        // Relationships
        builder.Entity<User>()
            .HasOne(p => p.Service)
            .WithOne(p => p.User);
            // .HasForeignKey(p => p.);
        
        builder.Entity<Service>().ToTable("Services");
        builder.Entity<Service>().HasKey(p => p.Id);
        builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //builder.Entity<Service>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Service>().Property(p => p.Description).HasMaxLength(120);
        
        // Users
            
        // Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Mail).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        

    

        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}