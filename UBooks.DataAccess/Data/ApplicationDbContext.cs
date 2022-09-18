﻿using Microsoft.EntityFrameworkCore;
using UBooks.Models;

namespace UBooks.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<CoverType> CoverTypes { get; set; }
    }
}