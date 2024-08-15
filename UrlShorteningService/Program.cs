using DataAccess;
using DataAccess.Repository;
using DataContracts.Contracts;
using Microsoft.EntityFrameworkCore;
using Service.Services;
using ServiceContracts.Contracts;
using UrlShorteningService.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUrlManagementRepository, UrlManagementRepository>();
builder.Services.AddTransient<IUrlManagementService, UrlManagementService>();
builder.Services.AddProblemDetails(options => options.CustomizeProblemDetails = (context) =>
{
    var urlErrorFeature = context.HttpContext.Features.Get<UrlCustomError>();
    if (urlErrorFeature is not null)
    {
        (string Detail, string Type, string title, string Instance) details = urlErrorFeature.CustomError switch
        {
            UrlErrorType.InvalidUrl => (
                "The provided Url is invalid", "https://localhost:5289/invalidUrl", "Invalid Url",
                "Please enter a valid Url")
        };
    }
});
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
