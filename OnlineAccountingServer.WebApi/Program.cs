using Microsoft.AspNetCore.Identity;
using OnlineAccountingServer.Domain.AppEntities.Identity;
using OnlineAccountingServer.WebApi.Configurations;
using OnlineAccountingServer.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);
//deneme
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();


using (var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser
        {
            UserName = "sena",
            Email = "senapksnn@gmail.com",
            Id = Guid.NewGuid().ToString(),
            NameLastName = " Sena Peksin"
        },"Password12*").Wait();
    }
}

app.Run();
