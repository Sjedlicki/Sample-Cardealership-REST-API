using DotNetCoreMVCRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreMVCRestApi.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Car { get; set; }
    }
}
