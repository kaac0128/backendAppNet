﻿using backendAppNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace backendAppNet.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options) 
        {
        
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Courses>? Courses { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public  DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        
    }
}
