using CustomerApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApp.Infrastructure
{
    public class DataInitializer
    {
        private readonly CustomerDbContext _dbContext;

        public DataInitializer(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            if (!_dbContext.Customers.Any())
            {
                _dbContext.Customers.AddRange(
                    new Customer { Name = "Anna", Age = 30, Gender = Gender.Female },
                    new Customer { Name = "Björn", Age = 25, Gender = Gender.Male },
                    new Customer { Name = "Carla", Age = 28, Gender = Gender.Female },
                    new Customer { Name = "David", Age = 35, Gender = Gender.Male },
                    new Customer { Name = "Eva", Age = 22, Gender = Gender.Other }
                );
                _dbContext.SaveChanges();
            }
        }
    }
}
