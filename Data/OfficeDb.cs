using api.CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace api.CRUD.Data
{
    public class OfficeDb : DbContext
    {
        public OfficeDb(DbContextOptions<OfficeDb> options) : base(options) 
        { 
         
        }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
