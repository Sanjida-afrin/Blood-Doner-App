using BloodDoner.Mvc.Configuration;
using BloodDoner.Mvc.Data;
using BloodDoner.Mvc.Data.UnitOfWork;
using BloodDoner.Mvc.Mapping;
using BloodDoner.Mvc.Middleware;
using BloodDoner.Mvc.Repositories.Implementations;
using BloodDoner.Mvc.Repositories.Interfaces;
using BloodDoner.Mvc.Services.Implementation;
using BloodDoner.Mvc.Services.Implementations;
using BloodDoner.Mvc.Services.Interfaces;
using BloodDoner.Mvc.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using BloodDoner.Mvc.Logger;
using BloodDoner.Mvc.Models.ValidationAttributes;
using BloodDoner.Mvc.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BloodDonerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<BloodDonerDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Services.AddSerilog();
// builder.Logging.AddProvider(new CustomLoggerProvider());

builder.Services.AddScoped<IBloodDonerRepository, BloodDonerRepository>();
builder.Services.AddScoped<IBloodDonerService, BloodDonerService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<UniqueEmailFilter>();

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("MailSettings"));
//builder.Services.AddAuthorization(options =>
//{
//    AuthorizationPolicy.AddPolicies(options);
//});

builder.Services.AddOptions<EmailSettings>()
    .BindConfiguration("EmailSettings")
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddControllers(options =>
{
    // options.Filters.Add<DonorAuthorizationFilter>(order: 1);
    options.Filters.Add<GlobalExceptionFilter>();
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

await app.SeedDatabaseAsync();

app.UseSerilogRequestLogging();

app.Run();