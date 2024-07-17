using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Northwind.GraphQL.Service;

public class Query
{
    public string GetGreeting() => "Hello, World!";
    public string Farewell() => "Ciao! Ciao!";
    public int RollTheDie() => Random.Shared.Next(1, 7);

    public IQueryable<Company> GetCompanies([Service] RepositoryContext context)
    {
        var companies = context.Companies;

        foreach (var company in companies)
        {
            if(company.Employees != null)
            {
                company.Employees.ToList();
            }
        }

        return context.Companies;
    }
    public IQueryable<Employee> GetEmployees([Service] RepositoryContext context)
    {
        return context.Employees;
    }


    public Company? GetCompany(RepositoryContext context, Guid categoryId) => context.Companies.SingleOrDefault(c => c.Id == categoryId);
}