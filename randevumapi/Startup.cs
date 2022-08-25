using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using randevumapi.Middleware;
using randevumapi.Objects.SettingsModel;
using randevumapi.Service;
using RandevumAPI.Helpers;
using RandevumAPI.Interface;
using RandevumAPI.Service;
using Repository;
using Microsoft.AspNetCore.Http;

namespace RandevumAPI
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

            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));

            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
               serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddControllers();

            var appSettingsSection = Configuration.GetSection("TokenSettings");
            services.Configure<TokenSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<TokenSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
               {
                   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })
                .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddSingleton(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddTransient<IEmailService, EmailService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IImageService, ImageService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
           });
        }
    }
}