using Concessionaria.Data;
using Concessionaria.Services;
using Concessionaria.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => {
                               options.Conventions.AuthorizeFolder("/Marcas");
                               options.Conventions.AuthorizeFolder("/Opcionais");
});

builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddDbContext<ConcessionariaDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ConcessionariaDbContext>();


builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    // Lockout settings
    options.Lockout.MaxFailedAccessAttempts = 30;
    options.Lockout.AllowedForNewUsers = true;
    // User settings
    options.User.RequireUniqueEmail = true;
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var context = new ConcessionariaDbContext();
context.Database.Migrate();

app.UseHttpsRedirection();
app.UseStaticFiles(); //Para acessar os it ens est�ticos de wwwroot

app.UseRouting();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapRazorPages(); //Para acessar as Razor Pages

app.Run();
