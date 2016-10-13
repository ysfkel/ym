using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NewGen.DomainModel.Models;
using NewGen.Infrastrcuture.Data;
using NewGen.Infrastrcuture.Data.Repository;
using NewGen.DomainModel.Repository;
using Microsoft.AspNetCore.Http;


namespace ceazar
{
    //
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //.AddJsonFile($"appsettings.json.{env.EnvironmentName}.json",optional:true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<ApplicationDbContext>(options=>
            // options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            //    services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
            // services.AddDbContext<ApplicationDbContext>(option=>option.UseInMemoryDatabase());

            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            bool useInMemoryProvider = bool.Parse(Configuration["ConnectionStrings:InMemoryProvider"]);

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                switch (useInMemoryProvider)
                {
                    case true:
                        options.UseInMemoryDatabase();
                        break;
                    default:
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                       //  options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly("NewGen.Api"));
                        break;
                }
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            try
            {
                loggerFactory.AddConsole();

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                     //  app.UseBrowserLink();
                        app.UseDeveloperExceptionPage();
                        app.UseDatabaseErrorPage();
                }

                app.UseStaticFiles();

                app.UseMvc(r =>
                {
                    r.MapRoute(
                        name: "default",
                        template: "{Controller=Home}/{action=Index}/{id?}"
                    );
                });
            }
            catch (Exception ex)
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync(ex.Message);
                });
                //          app.Run(async context =>
                // {
                //     context.Response.ContentType = "text/plain";
                //     await context.Response.WriteAsync(ex.Message);
                // });
            }
        }
    }
}
