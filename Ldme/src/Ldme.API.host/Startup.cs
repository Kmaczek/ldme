﻿using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ldme.Persistence.Repositories;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Logic.Domains;
using Ldme.Models.Dtos;
using Ldme.Models.Factories;
using Ldme.Models.Models;
using Ldme.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ldme.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace Ldme.API.host
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            try
            {
                _env = env;
                var builder = new ConfigurationBuilder()
                    .SetBasePath(_env.ContentRootPath)
                    .AddJsonFile("apisettings.json", optional: true, reloadOnChange: false)
                    .AddEnvironmentVariables();
                if (env.IsDevelopment())
                {
                    builder.AddJsonFile($@"C:\Ldme\appsettings.{env.EnvironmentName}.json", optional: true);
                }
                Configuration = builder.Build();

                SetupLogger(env);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void SetupLogger(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Seq(Configuration["SeqUrl"])
                .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddCors(options =>
            { // don not put slashes to WithOrigins
                options.AddPolicy("AllowAll",
                    p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
                options.AddPolicy("AllowLocal",
                    p => p.WithOrigins(Configuration["WebsiteUrl"], Configuration["Local"]).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(config =>
                {
                    config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    config.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // if this is not eought unlock ReferenceHandling
                    //config.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.All;
                });

            services.AddIdentity<LdmeUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequiredLength = 3;
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents
                {
                    // override redirecting
                    OnRedirectToLogin = context =>
                    {
                        if (context.Request.Path.Value.StartsWith("/api"))
                        {
                            context.Response.StatusCode = 401;
                            return Task.FromResult(0);
                        }
                        context.Response.Redirect(context.RedirectUri);
                        return Task.FromResult(0);
                    }
                };
                //config.Cookies.ApplicationCookie
            })
            .AddEntityFrameworkStores<LdmeContext>();

            services.AddDbContext<LdmeContext>(config =>
            {
                var connection = Configuration["ConnectionStrings:EfContexConnection"];
                Log.Logger.Information($"Used connection string: {connection}");

                config.UseSqlServer(connection);
                if (_env.IsDevelopment())
                {
                    config.EnableSensitiveDataLogging();
                }
            });
            services.AddTransient<LdmeContextSeed>();
            services.AddTransient<PlayerFactory>();
            services.AddTransient<QuestDomain>();
            services.AddTransient<PlayerDomain>();
            services.AddTransient<RewardDomain>();
            services.AddTransient<FriendDomain>();

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IQuestRepository, QuestRepository>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IRepetitionRepository, RepetitionRepository>();
            services.AddScoped<IRewardRepository, RewardRepository>();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, LdmeContextSeed seed)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug(LogLevel.Information);
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
            }
            loggerFactory.AddSerilog();

            app.UseCors("AllowLocal");
            app.UseIdentity();
            app.UseMvc();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<LdmeUser, UserVM>().ReverseMap();
                cfg.CreateMap<Player, PlayerSearchDto>();
                cfg.CreateMap<QuestDto, Quest>()
                .ForMember(q => q.CreatedDate, m => m.MapFrom(qd => qd.StartTime))
                .ForMember(q => q.QuestCreatorId, m => m.MapFrom(qd => qd.FromPlayer))
                .ForMember(q => q.QuestOwnerId, m => m.MapFrom(qd => qd.ToPlayer))
                .ForMember(q => q.DeadlineDate, m => m.MapFrom(qd => qd.EndTime))
                .ReverseMap();
                cfg.CreateMap<Reward, CreateRewardDto>().ReverseMap();
            });

            seed.EnsureSeedData().Wait();
        }
    }
}
