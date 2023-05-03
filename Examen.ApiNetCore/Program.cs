using Examen.ApiNetCore.Entities;
using Examen.ApiNetCore.SqlDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ExamenDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/api/GetUserList", async (ExamenDbContext dbContext) =>
{
    List<Usuario> List = await dbContext.TblUsuarios.ToListAsync();
    return List != null ? Results.Ok(List) : Results.NotFound();
}).Produces<List<Usuario>>();


app.Run();

