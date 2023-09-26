using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quiz.Data.Data;
using Quiz.Data.Repositories.Interfaces;
using Quiz.Data.Repositories;
using Quiz.Models.Entities;
using AutoMapper;
using Quiz.Web;

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

builder.Services
    .AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<QuizDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Questions}/{id?}");

ApplyMigrationsAndSeedDb();

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