global using CRUD.Shared;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CRUD.Data.Context>(options =>
{
    options.UseSqlServer("workstation id=CrudBackFront.mssql.somee.com;packet size=4096;user id=linaccount_SQLLogin_1;pwd=vftzcq5h93;data source=CrudBackFront.mssql.somee.com;persist security info=False;initial catalog=CrudBackFront; Encrypt=false");
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("any_origin", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("any_origin");

var DbService = app.Services.CreateScope();
var context = DbService.ServiceProvider.GetRequiredService<CRUD.Data.Context>();
bool isCreated = context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
   app.UseSwagger();
    app.UseSwaggerUI();

CRUD.Conexión.SetStringConnection("workstation id=CrudBackFront.mssql.somee.com;packet size=4096;user id=linaccount_SQLLogin_1;pwd=vftzcq5h93;data source=CrudBackFront.mssql.somee.com;persist security info=False;initial catalog=CrudBackFront; Encrypt=false");
_=CRUD.Conexión.StartConnections();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
