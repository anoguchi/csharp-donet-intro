using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using EmployeeAPI;
using EmployeeAPI.Abstractions;
using EmployeeAPI.Employees;
using FluentValidation;


var employees = new List<Employee>
{
    new Employee { Id = 1, FirstName = "John", LastName = "Doe", Benefits = new List<EmployeeBenefits>
    {
        new EmployeeBenefits { BenefitType = BenefitType.Health, Cost = 100 },
        new EmployeeBenefits { BenefitType = BenefitType.Dental, Cost = 50 }
    }},
    new Employee { Id = 2, FirstName = "Jane", LastName = "Doe" }
};

var employeeRepository = new EmployeeRepository();
foreach (var employee in employees)
{
    employeeRepository.Create(employee);
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "EmployeeAPI.xml"));
});
builder.Services.AddSingleton<IRepository<Employee>>(employeeRepository);
builder.Services.AddProblemDetails();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers(options => 
{
    options.Filters.Add<FluentValidationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public partial class Program {}