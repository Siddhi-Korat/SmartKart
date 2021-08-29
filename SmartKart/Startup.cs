using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartCart.Repo.Context;
using SmartCart.Repo.Repositories;
using SmartCart.Repo.Repositories.Interfaces;
using SmartCart.Repo.Stores;
using SmartKart.MappingProfiles;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartKart
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
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddDbContext<SmartCartDBContext>(o =>
                o.UseLazyLoadingProxies().UseSqlServer(
                    Configuration.GetConnectionString("DeveloperDatabase")
                ));
            services.AddScoped(typeof(IStore<>), typeof(DBStore<>));
            services.AddScoped(typeof(IBaseManager<>), typeof(BaseManager<>));
            services.AddScoped(c => { return new ItemStore(c.GetRequiredService<SmartCartDBContext>()); });
            services.AddScoped(c => { return new ItemManager(c.GetRequiredService<ItemStore>()); });
            services.AddScoped(c => { return new OrderStore(c.GetRequiredService<SmartCartDBContext>()); });
            services.AddScoped(c => { return new OrderManager(c.GetRequiredService<OrderStore>()); });
            services.AddScoped(c => { return new OrderItemStore(c.GetRequiredService<SmartCartDBContext>()); });
            services.AddScoped(c => { return new OrderItemManager(c.GetRequiredService<OrderItemStore>()); });
            services.AddScoped(c => { return new UserStore(c.GetRequiredService<SmartCartDBContext>()); });
            services.AddScoped(c => { return new UserManager(c.GetRequiredService<UserStore>()); });
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(swaggerOptions =>
            {
                swaggerOptions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Shopping Cart portal",
                    Description = "This API holds business logic related to the online shopping"
                });

                swaggerOptions.OrderActionsBy(x => x.RelativePath);
                var xmlFile = $"{typeof(Startup).Assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swaggerOptions.IncludeXmlComments(xmlPath);

                
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Api V1");
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelsExpandDepth(-1);
            });
        }
    }
}
