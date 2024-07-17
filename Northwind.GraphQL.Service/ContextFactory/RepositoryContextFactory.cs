using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace Northwind.GraphQL.Service;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
	public RepositoryContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.Build();

		var builder = new DbContextOptionsBuilder<RepositoryContext>()
			.UseSqlServer(("Server=CEMIGOGO;Database=Employee22;Trusted_Connection=True;encrypt=false"),
			b => b.MigrationsAssembly("Northwind.GraphQL.Service"));

		return new RepositoryContext(builder.Options);
	}
}