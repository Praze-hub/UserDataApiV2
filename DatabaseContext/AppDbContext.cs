using Microsoft.EntityFrameworkCore;
using WellaApi.Models;
namespace WellaApi.DatabaseContext{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }
        public DbSet<UserData> UserDataTable{get; set;}
    }
}