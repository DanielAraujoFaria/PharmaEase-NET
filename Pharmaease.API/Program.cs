using Microsoft.OpenApi.Models;
using Pharmaease.Repository.Interface;
using Pharmaease.Repository;
using Microsoft.EntityFrameworkCore;
using Pharmaease.Database;
using System.Reflection;
using Pharmaease.Services.OpenFDA;

namespace Pharmaease.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IMediServices, MediServices>();
            builder.Services.AddDbContext<PharmaDBContext>(options =>
                options.UseOracle(builder.Configuration.GetConnectionString("FIAPDatabase")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()    
                               .AllowAnyHeader();
                    });
            });
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pharma Ease",
                    Version = "v1",
                    Description = "Documenta��o da API para o servi�o de totem farmace�tico Pharma Ease\n" +
                    "\nArthur Mitsuo Yamamoto - RM551283 |" +
                    " Daniel dos Santos Araujo Faria - RM99067 |" +
                    " Enzo Lafer Gallucci - RM551111 |" +
                    " Francineldo Luan Martins Alvelino - RM99558 |" +
                    " Ramon Cezarino Lopez - RM551279 |",
                    Contact = new OpenApiContact
                    {
                        Name = "Grupo Pharma Ease",
                        Email = ""
                    }
                });

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
