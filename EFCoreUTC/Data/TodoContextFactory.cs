using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreUTC.Data
{
    public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            //appsettings.jsonからDB接続文字列を取得する
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");

            var optionBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionBuilder.UseNpgsql(connectionString);

            return new TodoContext(optionBuilder.Options);
        }
    }
}
