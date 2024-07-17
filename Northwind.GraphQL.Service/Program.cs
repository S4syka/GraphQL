using Microsoft.AspNetCore.Components;
using Northwind.GraphQL.Service;
using Repository;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<RepositoryContext>(opts => opts.UseSqlServer("Server=CEMIGOGO;Database=CompanyEmployeeDB;Trusted_Connection=True;encrypt=false"));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<RepositoryContext>()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", () => "Navigate to: https://localhost:5121/graphql");
app.MapGraphQL();
app.Run();
