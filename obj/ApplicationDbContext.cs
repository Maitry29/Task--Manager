using Microsoft.EntityFrameworkCore;
using Task_Manager.Models;
using Task = Task_Manager.Models.Task;
using System.Collections.Generic;

namespace Task_Manager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
        
        }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData(

                new Task { Id = 1, Title = "Meeting", Description = "Important Office meeting on monday 11 AM." },

                new Task { Id = 2, Title = "Birthday", Description = "Mom's birthday on saturday." }

                );
        }
    }
}
