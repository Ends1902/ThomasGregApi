using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ThomasGreg.Application.Services;
using ThomasGreg.Application.Validators;
using ThomasGreg.Domain.Interfaces.Repositories;
using ThomasGreg.Infrastructure.Repositories;
using ThomasGreg.Infrastructure.Repositories.Implementations;

namespace ThomasGreg.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegistraConexaoDoDapper(this IServiceCollection services)
        {

            services.AddTransient<IDbConnection>(sp =>
                new SqlConnection(
                    sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")
                )
            );
            return services;
        }

        public static IServiceCollection AdicionaServicos(this IServiceCollection services)
        {
            services.AddSingleton<TokenService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ILogradouroRepository, LogradouroRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ILogradouroService, LogradouroService>();

            return services;
        }

        public static IServiceCollection AdicionaValidacoes(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<ClienteDtoValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<LogradouroDtoValidator>();
                });

            return services;
        }

        public static IServiceCollection AdicionaSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Thomas Greg API",
                    Version = "v1"
                });
                // Configuração do Bearer token no Swagger
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Insira 'Bearer' seguido do token JWT.\n\nExemplo: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            return services;
        }

        public static IServiceCollection AdicionaAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
            return services;
        }
    }
}
