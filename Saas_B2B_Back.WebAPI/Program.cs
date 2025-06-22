
using Saas_B2B_Back.Application.Common;
using FluentValidation;
using Saas_B2B_Back.Application.Products.Commands;
using Saas_B2B_Back.Domain.Interfaces;
using Saas_B2B_Back.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Saas_B2B_Back.Application.Users.Commands.Validator;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddTransient<IServiceManager, ServiceManager>();

//// Register RepositoryFactory
//builder.Services.AddScoped<IGenericRepositoryFactory, GenericRepositoryFactory>();

////builder.Services.AddScoped<IRepository<Product>, GenericRepository<Product>>();

//// Register ApplicationUnitOfWork
//builder.Services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();

builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("Authentication"));

builder.Services.AddControllers();

builder.Services.AddDbContext<Saas_B2B_BackDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddProductCommandHandler).Assembly));


builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



// Add services to the container.
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {

        var securityKey = builder.Configuration["Authentication:SecurityKey"]; 
        var key = Encoding.UTF8.GetBytes(securityKey!);

        options.RequireHttpsMetadata = false; // Ensure HTTPS in production
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("Authentication:Issuer").Value!.ToString(),
            ValidAudience = builder.Configuration.GetSection("Authentication:Audience").Value!.ToString(),
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();


builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

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

app.Run();
