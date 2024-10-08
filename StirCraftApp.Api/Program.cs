using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using StirCraftApp.Infrastructure.Data;
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
