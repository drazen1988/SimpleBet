using DataAcesss;
using DataAcesss.Repositories.Implementations;
using DataAcesss.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using AutoMapper;
using DataAcesss.Mapper;
using Models.Helpers;
using DataAcesss.Data;
using Microsoft.AspNetCore.Identity;
using SimpleBet.Middleware;
using SimpleBet.Helpers;
using NLog.Web;
using NLog;

Logger logger = LogManager.GetLogger("errorLogger");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

    // Workaround for charts data
    builder.Services.AddSignalR(e =>
    {
        e.MaximumReceiveMessageSize = 102400000;
    });

    builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;

        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    })
    .AddErrorDescriber<MyIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

    builder.Services.ConfigureApplicationCookie(options =>
    {
        // Sets default page in case of unauthorized access to specific page.
        options.AccessDeniedPath = new PathString("/");

        // Sets default page in case of unauthenticated access to application.
        options.LoginPath = "/";
    });

    builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
    builder.Services.AddRazorPages();

    builder.Services.AddScoped<IMatchRepository, MatchRepositoy>();
    builder.Services.AddScoped<IBetRepository, BetRepository>();
    builder.Services.AddScoped<ICountryRepository, CountryRepository>();
    builder.Services.AddScoped<ILeaderBoardRepository, LeaderBoardRepository>();
    builder.Services.AddScoped<IStatsRepository, StatsRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IClanRepository, ClanRepository>();
    builder.Services.AddScoped<IMailRepository, MailRepository>();
    builder.Services.AddSyncfusionBlazor();
    builder.Services.AddHostedService<HostApplicationLifetimeEventsHostedService>();

    var config = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new MappingProfile());
    });

    var mapper = config.CreateMapper();

    builder.Services.AddSingleton(mapper);

    var app = builder.Build();

    //IHostApplicationLifetime lifetime = app.Lifetime;

    //lifetime.ApplicationStarted.Register(() => logger.Error("Application started."));
    //lifetime.ApplicationStopping.Register(() => logger.Error("Application stopped"));

    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjkzOTYwQDMyMzAyZTMyMmUzMEJiSnhFYjZ5L3lva2kxU3paZEtYczdHaHNXMXF5Qjg0RHZVR01FZGZEem89");

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseMiddleware<BlazorCookieLoginMiddleware>();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
    
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}

