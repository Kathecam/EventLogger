using System.Text.Json.Serialization;
using EventLogger.API;
using EventLogger.Domain.IRepositories;
using EventLogger.EventLogger.API;
using EventLogger.Infrastructure;
using EventLogger.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EventLoggerDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers().AddJsonOptions(options=>{ 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventLogRepository, EventLogRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseCors("Policy");
    app.UseSwaggerUI(c =>{ c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventLogger API v1"); c.RoutePrefix=string.Empty;});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
