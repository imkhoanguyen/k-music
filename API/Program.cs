using API.Authorization;
using API.Middleware;
using API.SignalR;
using KM.Application.Interfaces;
using KM.Application.Repositories;
using KM.Application.Service.Abstract;
using KM.Application.Service.Implementation;
using KM.Domain.Entities;
using KM.Infrastructure.Configuration;
using KM.Infrastructure.DataAccess;
using KM.Infrastructure.DataAccess.SeedData;
using KM.Infrastructure.Repositories;
using KM.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Config DB Context and ASP.NET Core Identity
builder.Services.AddDbContext<MusicContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityCore<AppUser>(opt =>
{
    opt.Password.RequiredLength = 6;
    opt.Password.RequireDigit = false; // không yêu cầu có số
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false; // không yêu cầu phải có chữ và số

    opt.SignIn.RequireConfirmedEmail = false;
})
    .AddRoles<AppRole>()
    .AddRoleManager<RoleManager<AppRole>>()
    .AddEntityFrameworkStores<MusicContext>()
    .AddSignInManager<SignInManager<AppUser>>()
    .AddUserManager<UserManager<AppUser>>()
    .AddDefaultTokenProviders(); // be able to create tokens for email confirmation


// be able to authenticate users using JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.SaveToken = true;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSetting:Key"])),
            ValidIssuer = builder.Configuration["JWTSetting:Issuer"], // domain name project api
            ValidateIssuer = true,
            ValidAudience = builder.Configuration["JWTSetting:Audience"], // người phát hành
            ValidateAudience = true,
            ValidateLifetime = true, // auto validate expired token
            ClockSkew = TimeSpan.Zero, // xóa bỏ lệch múi giờ
        };
        opt.Events = new JwtBearerEvents()
        {
            // 2 nếu có throw exception chạy xuống 3 rồi 4
            // vào đây khi controller có authorize
            OnTokenValidated = context =>
            {
                var tokenService = context.HttpContext.RequestServices.GetRequiredService<ITokenService>();
                return tokenService.ValidToken(context);
            },
            // 3
            OnAuthenticationFailed = context =>
            {
                return Task.CompletedTask;
            },
            // 1
            // luôn vào đầu tiên
            OnMessageReceived = context =>
            {
                return Task.CompletedTask;
            },
            //4 
            OnChallenge = context =>
            {
                return Task.CompletedTask;
            }
        };
    });



// register DI
builder.Services.AddSignalR();
builder.Services.Configure<CloudinaryConfig>(builder.Configuration.GetSection(CloudinaryConfig.ConfigName));
builder.Services.Configure<VNPayConfig>(
                builder.Configuration.GetSection(VNPayConfig.ConfigName));
builder.Services.Configure<TokenConfig>(builder.Configuration.GetSection(TokenConfig.ConfigName));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<ISingerService, SingerService>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPlaylistService, PlaylistService>();
builder.Services.AddScoped<IVipPackageService, VipPackageService>();
builder.Services.AddScoped<IVnPayService, VnPayService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICommentService, CommentService>();


// register policy
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();


app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
.WithOrigins("https://localhost:4200", "http://localhost:4200"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<CommentHub>("hubs/comment");

// seed data
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<MusicContext>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();

    await context.Database.MigrateAsync();
    await RoleSeed.SeedAsync(roleManager);
    await UserSeed.SeedAsync(userManager);
    await GenreSeed.SeedAsync(context);
    await SingerSeed.SeedAsync(context);
    await SongSeed.SeedAsync(context);
    await PlaylistSeed.SeedAsync(context, userManager);
    await RoleClaimSeed.SeedAsync(context, roleManager);
} catch(Exception ex)
{
    Console.WriteLine(ex);
    throw;
}


app.Run();
