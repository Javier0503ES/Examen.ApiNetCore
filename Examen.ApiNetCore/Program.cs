using Examen.ApiNetCore.Entities;
using Examen.ApiNetCore.SqlDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ExamenDbContext>();


var app = builder.Build();

#region User

app.MapGet("/api/GetUserList", async (ExamenDbContext dbContext) =>
{
	List<Usuario> List = await dbContext.TblUsuarios.ToListAsync();
	return List != null ? Results.Ok(List) : Results.NotFound();
}).Produces<List<Usuario>>();

app.MapGet("/api/GetUserValid", async (string userName, string password, ExamenDbContext dbContext) =>
{
	if (dbContext == null)
	{
		return Results.NotFound();
	}

	Usuario user = await dbContext.TblUsuarios.Where(q => q.Login.ToUpper().Equals(userName.ToUpper(), StringComparison.Ordinal)
													   && q.Password.ToUpper().Equals(password.ToUpper(), StringComparison.Ordinal)
												&& q.Activo.Equals(true)).FirstOrDefaultAsync();
	return user != null ? Results.Ok(user) : Results.NotFound();
}).Produces<Usuario>();

app.MapPost("/api/AddUser", async (Usuario usuario, ExamenDbContext dbContext) =>
{
	dbContext.TblUsuarios.Add(new Usuario
	{
		Nombre = usuario.Nombre,
		ApPaterno = usuario.ApPaterno,
		ApMaterno = usuario.ApMaterno,
		Activo = true,
		Login = usuario.Login,
		Password = usuario.Password
	});
	await dbContext.SaveChangesAsync();

	return Results.Ok();
}).Produces(StatusCodes.Status200OK);

app.MapPost("/api/DeleteUser", async (int id, ExamenDbContext dbContext) =>
{
	var u = dbContext.TblUsuarios.Where(q => q.Id.Equals(id)).FirstOrDefault();
	if (u == null)
	{
		return Results.NotFound();
	}
	dbContext.TblUsuarios.Remove(u);
	await dbContext.SaveChangesAsync();
	return Results.Ok();
}).Produces(StatusCodes.Status200OK);


#endregion



app.MapGet("/api/GetExamen", async (int idUser, ExamenDbContext dbContext) =>
{
	var x = await dbContext.TblUsuarios.ToListAsync();

	return Results.Ok(x);
}).Produces<IEnumerable<Usuario>>();

//record BitarocaModel(int idUsuario, int accion,string descripcion );
app.MapPost("/api/AddItemBitacora", async ([FromBody]Bitacora bitacora, ExamenDbContext dbContext) =>
{
	try
	{
		dbContext.TblBitacora.Add(new Bitacora
		{
			IdAccion = bitacora.IdAccion,
			IdUsuario = bitacora.IdUsuario,
			Observacion = bitacora.Observacion,
			FechaRegistro =DateTime.UtcNow
		}); ;
	await dbContext.SaveChangesAsync();
	}
	catch (Exception ex )
	{

		throw;
	}
	
	return Results.Ok();
}).Produces(StatusCodes.Status200OK);

app.Run();

