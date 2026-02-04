using Infrastructure.DBConfiguration.DBSettings;
using Infrastructure.DBConfiguration.ServiceContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Infrastructure.ContextFactory
{
    public class ServicesContextFactory : IDesignTimeDbContextFactory<ServicesContext>
    {
        private readonly DataBaseSettings _dataBaseSettings;

        public ServicesContextFactory(IOptions<DataBaseSettings> options)
        {
            _dataBaseSettings = options.Value;
        }

        public ServicesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServicesContext>()
                .UseSqlServer(_dataBaseSettings.ConnectionString,
                op => op.MigrationsAssembly(typeof(ServicesContextFactory).Assembly.FullName));

            return new ServicesContext(optionsBuilder.Options);
        }
    }
}
