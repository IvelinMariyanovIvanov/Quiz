using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quiz.Data.Data;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Data.Repositories;
using Quiz.Models.Entities;
using AutoMapper;
using Quiz.Web;
using Microsoft.AspNetCore.Builder;
using Quiz.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// congigure/ connect  sql server
builder.Services.AddDbContext<QuizDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// config auto mapper
IMapper autoMapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(autoMapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Authentication
builder.Services.AddAuthentication
    (options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme);

// Authorization
builder.Services
    .AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<QuizDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registrer IHttpClintFactory 
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Questions}/{action=Questions}/{id?}");

ApplyMigrationsAndSeedDb();

await SeedUsersAndRolesAsync();

app.Run();

void ApplyMigrationsAndSeedDb()
{
    using (IServiceScope scope = app.Services.CreateScope())
    {
        QuizDbContext db = scope.ServiceProvider.GetRequiredService<QuizDbContext>();

        if (db.Database.GetPendingMigrations().Count() > 0)
        {
            db.Database.Migrate();
        }
    }
}

async Task SeedUsersAndRolesAsync()
{
    using (var scope = app.Services.CreateScope())
    {
        // Roles
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Add Admin
        if (!await roleManager.RoleExistsAsync(Constants.AdminRole))
                await roleManager.CreateAsync(new IdentityRole(Constants.AdminRole));

        // Add user
        if (!await roleManager.RoleExistsAsync(Constants.UserRole))
                await roleManager.CreateAsync(new IdentityRole(Constants.UserRole));

        //Users
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        string adminUserEmail = "admin@test.com";

        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

        if (adminUser == null)
        {
            var newAdminUser = new User()
            {
                FullName = "Admin 1",
                UserName = adminUserEmail,
                Email = adminUserEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(newAdminUser, Constants.AdminPassword);
            await userManager.AddToRoleAsync(newAdminUser, Constants.AdminRole);
        }


        string appUserEmail = "user@test.com";
        var appUser = await userManager.FindByEmailAsync(appUserEmail);

        if (appUser == null)
        {
            var newAppUser = new User()
            {
                FullName = "User 1",
                UserName = appUserEmail,
                Email = appUserEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(newAppUser, Constants.UserPassword);
            await userManager.AddToRoleAsync(newAppUser, Constants.UserRole);
        }
    }
}