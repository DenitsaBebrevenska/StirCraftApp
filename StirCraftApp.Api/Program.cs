using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StirCraftApp.Infrastructure.Data;
using StirCraftApp.Infrastructure.Data.SeedData;
using StirCraftApp.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "StirCraft API",
		Version = "v1"
	});
});

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<AppUser>()
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<StirCraftDbContext>();

var app = builder.Build();

try
{
	using var scope = app.Services.CreateScope();
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<StirCraftDbContext>();

	// Apply any pending migrations
	await context.Database.MigrateAsync();

	// Seed the database if it is not already seeded
	await SeedDataHelper.SeedAllAsync(context);

}
catch (Exception ex)
{
	Console.WriteLine(ex);
	//do I want to throw?
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("v1/swagger.json", "StirCraft API V1");
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGroup("api").MapIdentityApi<AppUser>();

app.Run();
