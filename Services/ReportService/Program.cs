using Common.DTOs;
using Common.RabbitMQItem;
using Microsoft.EntityFrameworkCore;
using ReportService.Config;
using ReportService.Data;
using ReportService.Messaging;
using ReportService.Repositories;
using ReportService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ReportDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IReportRepository,ReportRepository>();
builder.Services.AddScoped<IReportService, ReportService.Services.ReportService>();
builder.Services.AddScoped<IReportDetailRepository, ReportDetailRepository>();
builder.Services.AddScoped<IReportDetailService, ReportDetailService>();
builder.Services.AddHostedService<ReportGeneratedConsumer>();
builder.Services.AddSingleton<IRabbitMqProducer<RabbitMqRequestDto>, RabbitMqProducer<RabbitMqRequestDto>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();
app.UseCors("AllowAll");
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.MapControllers();

app.Run();
