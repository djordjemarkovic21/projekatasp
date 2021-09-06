using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Core;
using Api.Core.FakeActors;
using Api.Core.Jwt;
using Application;
using Application.Commands.BasketCommands;
using Application.Commands.CityCommand;
using Application.Commands.CountryCommands;
using Application.Commands.DestinationCommand;
using Application.Commands.TimetableCommands;
using Application.Commands.UserCommands;
using Application.Email;
using Application.Logger;
using Application.Queries;
using Application.Queries.BasketQueries;
using Application.Queries.CityQueries;
using Application.Queries.CountryQueries;
using Application.Queries.DestinationQueries;
using Application.Queries.LogQueries;
using Application.Queries.TimetableQueries;
using DataAccess;
using Implementation.Commands.Basket;
using Implementation.Commands.CityCommands;
using Implementation.Commands.CountryCommands;
using Implementation.Commands.DesinationCommands;
using Implementation.Commands.TimetableCommands;
using Implementation.Commands.UserCommands;
using Implementation.Commands.UserCommands;
using Implementation.Email;
using Implementation.Logger;
using Implementation.Queries.BasketQueries;
using Implementation.Queries.CityQueries;
using Implementation.Queries.CountryQueries;
using Implementation.Queries.DestinationQueries;
using Implementation.Queries.LogQueries;
using Implementation.Queries.TimetableQueries;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<Context>();
            services.AddAutoMapper(typeof(EFGetCountryQuery).Assembly);

            ///validator
            services.AddTransient<UserLoginRequestValidator>();
            services.AddTransient<CreateUserValidator>();

            services.AddTransient<CreateBasketValidator>();
            services.AddTransient<CreateCityValidator>();
            services.AddTransient<CreateCountryValidator>();
            services.AddTransient<CreateTimetableValidator>();
            services.AddTransient<DestinationValidator>();
            services.AddTransient<UpdateCityValidator>();
            services.AddTransient<UpdateCountryValidator>();

            ///users - login...
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<JwtManager>();
            services.AddTransient<IApplicationActor,FakeApiActor>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();

            ///countries
            services.AddTransient<IGetCountriesQuery, EFGetCountriesQuery>();
            services.AddTransient<IGetCountryQuery, EFGetCountryQuery>();
            services.AddTransient<ICreateCountryCommand, EFCreateCountryCommand>();
            services.AddTransient<IDeleteCountryCommand, EFDeleteCountryCommand>();
            services.AddTransient<IUpdateCountryCommand, EFUpdateCountryCommand>();

            ///cities
            services.AddTransient<IGetCitiesQuery, EFGetCitiesQuery>();
            services.AddTransient<IGetCityQuery, EFGetCityQuery>();
            services.AddTransient<ICreateCityCommand, EFCreateCityCommand>();
            services.AddTransient<IDeleteCityCommand, EFDeleteCityCommand>();
            services.AddTransient<IUpdateCityCommand, EFUpdateCityCommand>();

            ///destinations
            services.AddTransient<IGetDestinationsQuery, EFGetDestinationsQuery>();
            services.AddTransient<IGetDestinationQuery, EFGetDestinationQuery>();
            services.AddTransient<ICreateDestinationCommand, EFCreateDestinationCommand>();
            services.AddTransient<IDeleteDestinationCommand, EFDeleteDestinationCommand>();
            services.AddTransient<IUpdateDestinationCommand, EFUpdateDestinationCommand>();

            ///timetables
            services.AddTransient<IGetTimetablesQuery, EFGetTimetablesQuery>();
            services.AddTransient<IGetTimetableQuery, EFGetTimetableQuery>();
            services.AddTransient<ICreateTimetableCommand, EFCreateTimetableCommand>();
            services.AddTransient<IDeleteTimetableCommand, EFDeleteTimetableCommand>();
            services.AddTransient<IUpdateTimetableCommand, EFUpdateTimetableCommand>();

            ///basket
            services.AddTransient<IGetBasketsQuery, EFGetBasketsQuery>();
            services.AddTransient<IGetBasketQuery, EFGetBasketQuery>();
            services.AddTransient<ICreateBasketCommand, EFCreateBasketCommand>();
            services.AddTransient<IDeleteBasketCommand, EFDeleteBasketCommand>();
            services.AddTransient<IUpdateBasketCommand, EFUpdateBasketCommand>();

            ///user
            services.AddTransient<ICreateUserCommand, EFCreateUserCommand>();

            ///logs
            services.AddTransient<IGetLogsQuery, EFGetLogsQuery>();

            ///email
            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new UnauthorizedActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });



            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Travel Blog", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
