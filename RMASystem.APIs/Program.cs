using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RMASystem.DAL;
using RMASystem.BL;
using RMASystem.APIs;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

#region Default
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

#endregion

#region Database
var connectionString = builder.Configuration.GetConnectionString("cs");

builder.Services.AddDbContext<RMAContext>(options =>
    options.UseSqlServer(connectionString));

#endregion

#region Repos
// for this message Unable to resolve service 
// you need to register in program.cs with the dependency injection container to can ask for object

builder.Services.AddScoped<IRetailCustomersRepo, RetailCustomersRepo>();
builder.Services.AddScoped<IReceivedRequestsRepo, ReceivedRequestsRepo>();
builder.Services.AddScoped<APIReceivedRequests>();
builder.Services.AddScoped<IUserAuthRepo, UserAuthRepo>();

#endregion

#region Managers

builder.Services.AddScoped<IRetailCustomersManager, RetailCustomersManager>();
builder.Services.AddScoped<IReceivedRequestsManager, ReceivedRequestsManager>();
builder.Services.AddScoped<IUserAuthManger, UserAuthManger>();

#endregion

#region Identity
// must put Identity before Authentication 

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    //options.Tokens.EmailConfirmationTokenProvider = "emailConfirmation";
    //options.Tokens.PasswordResetTokenProvider = "passwordReset";

    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;

    options.User.RequireUniqueEmail = true;  

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
})
    .AddEntityFrameworkStores<RMAContext>()
    .AddDefaultTokenProviders(); // for Generate reset passwored

//// Configure a custom token provider for password reset
//builder.Services.Configure<PasswordOptions>(options =>
//{
//    options.ResetTokenProvider = "passwordReset";
//});

//builder.Services.AddScoped<IUserTwoFactorTokenProvider<ApplicationUser>, PasswordResetTokenProvider>();

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Cool"; // AnyName
    options.DefaultChallengeScheme = "Cool";
})
    .AddJwtBearer("Cool", options =>
    {
        string keyString = builder.Configuration.GetValue<string>("SecretKey")!;
        byte[] keyInBytes = Encoding.ASCII.GetBytes(keyString);
        var key = new SymmetricSecurityKey(keyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

#endregion

#region Authorization

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ManagersOnly", policy =>
//        policy
//            .RequireClaim(ClaimTypes.Role, "Manager", "CEO")
//            .RequireClaim(ClaimTypes.NameIdentifier));

//    options.AddPolicy("EmployeesOnly", policy =>
//        policy
//            .RequireClaim(ClaimTypes.Role, "Employee", "Manager", "CEO")
//            .RequireClaim(ClaimTypes.NameIdentifier));
//});

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");  

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<APIRequestsHandlers>(); // CustomMiddelware

app.MapControllers();

app.Run();
