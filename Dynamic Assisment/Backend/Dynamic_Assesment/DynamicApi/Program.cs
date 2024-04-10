using Application.Interface;
using Infrastructure.Contexr;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//add dbcontext
builder.Services.AddDbContext<DynamicContext>(options =>
    options.UseSqlServer(
        builder.
        Configuration.GetConnectionString("DefaultConnection"),
        builder => builder.MigrationsAssembly(typeof(DynamicContext).Assembly.FullName)));


builder.Services.AddScoped(
    (Func<IServiceProvider, IDynamicContext>)(provider => provider.GetRequiredService<DynamicContext>())
);


builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


//for connectivity with frontend
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowOrigin",
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowedToAllowWildcardSubdomains());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
