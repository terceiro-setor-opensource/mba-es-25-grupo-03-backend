using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

namespace Infra
{
    public class Swagger
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Swagger

            var logo = new Dictionary<string, IOpenApiExtension>
            {
                {"x-logo", new OpenApiObject
                    {
                        //{"url", new OpenApiString("/assets/images/")},
                        { "altText", new OpenApiString("")}
                    }
                },
            };

            services.AddSwaggerGen(options =>
            {
                OpenApiContact contact = new OpenApiContact
                {
                    Email = "",
                    Name = "",
                    Url = new Uri("https://www.google.com")
                };

                OpenApiLicense licence = new OpenApiLicense
                {
                    Url = new Uri("https://www.google.com"),
                    Name = "",
                };

                options.SwaggerDoc("none", new OpenApiInfo
                {
                    Contact = contact,
                    Description = "",
                    License = licence,
                    TermsOfService = new Uri("https://www.google.com"),
                    Title = "none",
                    Version = "0",
                    Extensions = logo
                });

                options.SwaggerDoc("Login", new OpenApiInfo
                {
                    Contact = contact,
                    Description = "Login",
                    License = licence,
                    TermsOfService = new Uri("https://www.google.com"),
                    Title = "Login",
                    Version = "V1",
                    Extensions = logo
                });

                options.SwaggerDoc("Curso", new OpenApiInfo
                {
                    Contact = contact,
                    Description = "Curso",
                    License = licence,
                    TermsOfService = new Uri("https://www.google.com"),
                    Title = "Curso",
                    Version = "V1",
                    Extensions = logo
                });

                options.SwaggerDoc("Usuario", new OpenApiInfo
                {
                    Contact = contact,
                    Description = "Usuario",
                    License = licence,
                    TermsOfService = new Uri("https://www.google.com"),
                    Title = "Usuario",
                    Version = "V1",
                    Extensions = logo
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "authorization",
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                string xmlPath = Path.Combine(AppContext.BaseDirectory, "BaseApi.xml");
                options.IncludeXmlComments(xmlPath);
            });

            #endregion Swagger
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("none/swagger.json", "none");
                c.SwaggerEndpoint("Login/swagger.json", "Login");
                c.SwaggerEndpoint("Curso/swagger.json", "Curso");
                c.SwaggerEndpoint("Usuario/swagger.json", "Usuario");

                c.InjectStylesheet("custom.css");
                c.InjectJavascript("custom.js");
            });
        }

        public static void RegisterServicesAuth(IServiceCollection services)
        {
            #region Swagger

            services.AddSwaggerGen(c =>
            {
                OpenApiContact contact = new OpenApiContact
                {
                    Email = "",
                    Name = "",
                    Url = new Uri("")
                };

                OpenApiLicense licence = new OpenApiLicense
                {
                    Url = new Uri(""),
                    Name = ""
                };

                c.SwaggerDoc("Auth", new OpenApiInfo
                {
                    Contact = contact,
                    Description = "API - Auth",
                    License = licence,
                    TermsOfService = new Uri(""),
                    Title = "Auth",
                    Version = "V1"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            #endregion Swagger
        }

        public static void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("Auth/swagger.json", "API v1 Auth"); });
        }
    }
}