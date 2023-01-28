using IdentityServer4Integration.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddIdentityServer()
                .AddInMemoryApiScopes(InMemoryConfig.GetApiScopes())
                .AddInMemoryApiResources(InMemoryConfig.GetApiResources())
                .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
                .AddTestUsers(InMemoryConfig.GetUsers())
                .AddInMemoryClients(InMemoryConfig.GetClients())
                .AddDeveloperSigningCredential(); // not something that we want to use in a production environment;

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.Authority = "https://localhost:5005";
    opt.Audience = "companyApi";
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.MapControllers();

app.Run();