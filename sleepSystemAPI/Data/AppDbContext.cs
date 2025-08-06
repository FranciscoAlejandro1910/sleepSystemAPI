using Microsoft.EntityFrameworkCore;
using sleepSystemAPI.Models;


namespace sleepSystemAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        
    }
}
