using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using StirCraftApp.Api.Extensions;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext(builder.Configuration);

builder.Services.AddServices();
builder.Services.AddCors();
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

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<AppUser>(opt =>
{
    opt.User.RequireUniqueEmail = true;

})
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
    //app.UseDeveloperExceptionPage();
}

app.UseGlobalExceptionMiddleware();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
    .WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.MapGroup("api").MapIdentityApi<AppUser>();

app.Run();
