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
	string userUper = userName.ToUpper();
    string passUper = password.ToUpper();


    Usuario user = await dbContext.TblUsuarios.Where(q => q.Login.ToUpper().Equals(userUper)
													   && q.Password.ToUpper().Equals(passUper)
												&& q.Activo.Equals(true)).FirstOrDefaultAsync();
	return user != null ? Results.Ok(user) : Results.NotFound();
}).Produces<Usuario>();

app.MapGet("/api/GetUserById", async (int Id, ExamenDbContext dbContext) =>
{
	if (dbContext == null)
	{
		return Results.NotFound();
	}
	Usuario user = await dbContext.TblUsuarios.Where(q => q.Id.Equals(Id)).FirstOrDefaultAsync();
	return user != null ? Results.Ok(user) : Results.NotFound();
}).Produces<Usuario>();

app.MapPost("/api/AddUser", async ([FromBody] Usuario usuario, ExamenDbContext dbContext) =>
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

app.MapPost("/api/UpdateUser", async ([FromBody] Usuario user, ExamenDbContext dbContext) =>
{
	var u = dbContext.TblUsuarios.Where(q => q.Id.Equals(user.Id)).FirstOrDefault();
	if (u == null)
	{
		return Results.NotFound();
	}
	u.Nombre = user.Nombre;
	u.ApPaterno = user.ApPaterno;
	u.ApMaterno = user.ApMaterno;
	u.Activo = user.Activo;
	u.Login = user.Login;
	u.Password = user.Password;

    await dbContext.SaveChangesAsync();
    return Results.Ok();
}).Produces(StatusCodes.Status200OK);

app.MapGet("/api/DeleteUser", async (int id, ExamenDbContext dbContext) =>
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


app.MapGet("/api/GetExamenes", async ( int Id, ExamenDbContext dbContext) =>
{
	var response = dbContext.ExamUser.Where(q => q.IdUser.Equals(Id)).ToList();
    return response?? new List<Test>();

}).Produces<List<Usuario>>();



app.Run();

