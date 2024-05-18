using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using WorkersManagment.Api.Mapping;
using WorkersManagment.Core.Repositories;
using WorkersManagment.Core.Services;
using WorkersManagment.Data;
using WorkersManagment.Data.Repositories;
using WorkersManagment.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var policy =" policy" ;
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IPositionWorkerRepository, PositionWorkerRepository>();

builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IPositionService, PositionService>();
//builder.Services.AddScoped<IPositionWorkerService, PositionWorkerService>();

builder.Services.AddAutoMapper(typeof(PostModelsMappingProfile));
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy);
app.UseAuthorization();

app.MapControllers();

app.Run();
