using api.CRUD.Data;
using api.CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

internal class Program
{
    private static OfficeDb db;
    private static object id;
    private static object e;

    private static async Task<IResult> Main(string[] args, Employee employee, Employee? employess)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        //Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
        builder.Services.AddDbContext<OfficeDb>(options =>
        options.UseNpgsql(connectionString));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapPost("/employees", async (Employee e, OfficeDb db) =>
        {
            db.Employee.Add(e);
            await db.SaveChangesAsync();
            return Results.Created($"/employee/{e.Id}", e);

        });

        app.MapGet("/employees/{id:int}", async (int id, OfficeDb db) =>
        {
            return await db.Employees.FindAsync(id)
            is Employee e
            ? Results.Ok(e) : Results.NotFound(id);
        });

        app.MapGet("/employees/", async (OfficeDb db) => await db.Employees.ToListAsync());

        app.MapPut("/employees/{id:int}", async(int id, GetEmployeee(), OfficeDb db); =>
        {
            if (e.Id != id)
                return Results.BadRequest();
            var employess = await db.Employees.FindAsync(id);
            employess.Name = e.Name;
            employess.apellido = e.apellido;
            employess.mail = e.mail;

            await db.SaveChangesAsync();
            return Results.Ok(employess);
        });

        app.MapDelete("/employess/{id:int}", async (int id, OfficeDb db) =>
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee is null) return Results.NotFound();
            if (employee is not null)
            {
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
            }
            return Results.NoContent();
        }
        }); 



        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static object GetEmployeee()
    {
    object employeee = null;
    return employeee;
    }

    private static RequestDelegate async(int v, object id, Employee employee, object e, OfficeDb officeDb, object db)
    {
        throw new NotImplementedException();
    }
}