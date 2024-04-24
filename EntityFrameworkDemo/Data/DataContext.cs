using Microsoft.EntityFrameworkCore;
using EntityFrameworkDemo.Entities;

namespace EntityFrameworkDemo.Data
{
    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //table
        public DbSet<SuperHero> SuperHeroes { get; set; }  
    }

    

}
