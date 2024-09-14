using Microsoft.EntityFrameworkCore;
using WebApi_Formatter.Data;
using WebApi_Formatter.Repository.Abstract;
using WebApi_Formatter.Repository.Concrete;
using WebApi_Formatter.Services.Abstract;
using WebApi_Formatter.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
   
    //options.OutputFormatters.Insert(0, new VCardOutputFormatter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<StudentDBContext>(opt =>
{
    opt.UseSqlServer(conn);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
