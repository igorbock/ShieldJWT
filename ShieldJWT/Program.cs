var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .Build();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddScoped<TokenServiceAbstract, TokenService>();
builder.Services.AddScoped<IShieldUser, UserService>();
builder.Services.AddScoped<IShieldMail, MailService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordService>();
builder.Services.AddScoped<IShieldCompany, CompanyService>();
builder.Services.AddScoped<IShieldEntity<ShieldClaim>, ShieldClaimService>();
builder.Services.AddScoped<IShieldEntity<Log>, ShieldLogService>();
builder.Services.AddScoped<IShieldEntity<LogDeleteIteration>, ShieldLogDeleteIterationService>();

builder.Services.AddHostedService<LogService>();

builder.Services.AddDbContext<ShieldDbContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), bld =>
    {
        bld.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    });
});

builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add<CompanyActionFilter>();
});

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
