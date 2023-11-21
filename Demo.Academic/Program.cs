using Demo.Academic.Data;
using Demo.Academic.GrpcServices;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IFacultyRepository, FacultyRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddAutoMapper(typeof(Program));
var Configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddGrpc();
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
app.MapGrpcService<CourseInfoService>();
app.Run();
