using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMovies.Data;
using MyMovies.Repositories;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services;
using MyMovies.Services.Interfaces;

namespace MyMovies
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MyMoviesDbContext>(options => 
            options
            .UseLazyLoadingProxies()
            .UseSqlServer(Configuration.GetConnectionString("MyMovies")
            ));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options => {
                options.LoginPath = "/auth/signin";
                options.AccessDeniedPath = "/auth/accessdenied";
            });

            services.AddAuthorization(options =>
                options.AddPolicy(
                    "IsAdmin", 
                    policy => policy.RequireClaim("IsAdmin", "True"))
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IMoviesRepository, MoviesEFRepository>();
            services.AddTransient<IMoviesService, MovieService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IMovieCommentsRepository, MovieCommentsRepository>();
            services.AddTransient<IMovieCommentsService, MovieCommentsService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Movies}/{action=Overview}/{id?}");
            });
        }
    }
}
