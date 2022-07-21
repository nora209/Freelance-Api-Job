using App.BusinessLayer.AutoMapper;
using App.DataAccessLayer.Database;
using App.DataAccessLayer.Repository.IssueRepo;
using App.DataAccessLayer.Repository.PatientRepo;
using App.DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Context");
builder.Services.AddDbContext<HospitalContext>(option =>
   option.UseSqlServer(connectionString));
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IIssueRepo, IssueRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
