using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MojammatApi.Hubs;
using MojammatApi.Interfaces;
using MojammatApi.Repositories;
using MojammatApi.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;
//using MojammatApi.Hubs;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21)))
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jwtKey"]!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<IRequestedServiceRepository, RequestedServiceRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository > ();
builder.Services.AddScoped<INotificationRepository, NotificationRepository > ();
builder.Services.AddScoped<IAppSettingRepository, AppSettingRepository>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
});
//builder.Services.AddControllers().AddJsonOptions(options =>
// options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


builder.Services.AddSignalR();


var app = builder.Build();

var rootFolder = Path.Combine(app.Environment.ContentRootPath, "wwwroot/Upload/Files");
if (!Directory.Exists(rootFolder))
{
    Directory.CreateDirectory(rootFolder);
}


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.MapGet("/image/{imageName}", (string imageName) =>
{

    var contentRoot = app.Environment.ContentRootPath;
    var imagePath = Path.Combine(contentRoot, "wwwroot", "Upload", "Files", imageName);
    //var imagePath = Path.Combine("wwwroot", "Upload", "Files", imageName);
    if (!System.IO.File.Exists(imagePath))
    {
        return Results.NotFound("Image not found.");
    }

    var imageExtension = Path.GetExtension(imageName).TrimStart('.');
    var contentType = $"image/{imageExtension}";

    return Results.File(imagePath, contentType);
}).WithDisplayName("ShowImage");

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notification");

app.Run();

