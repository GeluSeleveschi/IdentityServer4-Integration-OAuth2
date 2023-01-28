using IdentityServer4Integration.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddIdentityServer()
                .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
                .AddTestUsers(InMemoryConfig.GetUsers())
                .AddInMemoryClients(InMemoryConfig.GetClients())
                .AddDeveloperSigningCredential(); // not something that we want to use in a production environment;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseIdentityServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
