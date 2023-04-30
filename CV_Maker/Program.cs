using CV_Maker.IRepository;
using CV_Maker.IServices;
using CV_Maker.Repository;
using CV_Maker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowspecification = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowspecification,
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.WithOrigins("http://localhost:4200");

        });



});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] " +
       "and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    //c.EnableAnnotations();
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});
IConfiguration configuration =new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();
string connection = configuration.GetConnectionString("CV_Maker");
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Cv_MakerDbDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("CV_Maker")));
IServiceCollection services = builder.Services;
builder.Services.AddScoped<IPersonalDetailsRepository, PersonalDetailsRepository>();
builder.Services.AddScoped<IPersonalDetailsService, PersonalDetailsService>();
builder.Services.AddScoped<ICVgenerator, CVgenerator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
