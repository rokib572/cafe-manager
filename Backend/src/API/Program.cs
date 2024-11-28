using API.Extensions;
using API.Filters;
using Application.Dependency;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configure Autofac as the DI container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container
builder.Services.AddControllers(options =>
{
	options.Filters.Add<ExceptionFilter>(); // Add custom exception filter
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Title = "Cafe Management API",
		Version = "v1",
		Description = "Clean Architecture API for Cafe management."
	});
});

// Add Application and Infrastructure services
builder.Services.AddCustomServices(builder.Configuration);
builder.Services.AddApplicationServices();

// Autofac Container configuration
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
	containerBuilder.RegisterModule(new ApplicationModule());
	containerBuilder.RegisterModule(new InfrastructureModule());
});

// Configure CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
		policy.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader());
});

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cafe and Employee Management API v1");
	});
}

// Configure middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

// Run the application
app.Run();