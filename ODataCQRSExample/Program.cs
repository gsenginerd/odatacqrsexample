using System.Reflection;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataCQRSExample.Data;
using ODataCQRSExample.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// AddJsonOptions configured to avoid object recursion in case of EF. See https://learn.microsoft.com/en-us/ef/core/querying/related-data/serialization
builder.Services.AddControllers().AddNewtonsoftJson(options=> options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ODataCqrsExampleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ODataExampleConnection")));
builder.Services.AddControllers().AddOData(options => options.Select().Filter().Count().OrderBy().Expand().SetMaxTop(2).AddRouteComponents("v1", GetEdmModel()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


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

app.UseODataRouteDebug();

app.Run();
return;


static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder modelBuilder = new();
    modelBuilder.EntitySet<Employee>("Employees");
    return modelBuilder.GetEdmModel();
}