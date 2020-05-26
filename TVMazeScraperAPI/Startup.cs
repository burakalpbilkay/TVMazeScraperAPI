﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Consumer;
using Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TVMazeScrapperAPI.Business;
using TVMazeScrapperAPI.Data.Connector;
using TVMazeScrapperAPI.Data.Repository;

namespace TVMazeScraperAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IConnector, ApiConnector>();
            services.AddScoped<IConsumeWebService,ConsumeWebService >();
            services.AddScoped<ITVShowRepository, TVShowRepository>();
            services.AddScoped<ITVShowBusiness, TVShowBusiness>();
            services.AddDbContextPool<TVMazeScraperContext>(options => options.UseSqlite("Data Source=tvmazescraper.db"), poolSize: 10);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeDatabase(app).GetAwaiter().GetResult();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }

        private async Task InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var tvShowBusiness = scope.ServiceProvider.GetRequiredService<ITVShowBusiness>();

                await tvShowBusiness.CreateAndPopulateDatabase();
            }
        }
    }
}