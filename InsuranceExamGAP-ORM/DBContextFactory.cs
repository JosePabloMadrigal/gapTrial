
using InsuranceExamGAP_ORM.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InsuranceExamGAP_ORM
{
    public class UsersDbContextFactory : IDesignTimeDbContextFactory<InsuranceContext>
    {
        public InsuranceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InsuranceContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.Configuration.GetConnectionString("DefaultConnection"));

            return new InsuranceContext(optionsBuilder.Options);
        }
    }
}