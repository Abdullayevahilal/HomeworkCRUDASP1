using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeworkASPCRUD.Models;

namespace HomeworkASPCRUD.Data
{
    public class HomeworkDbContext : DbContext
    {
        public HomeworkDbContext(DbContextOptions<HomeworkDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
