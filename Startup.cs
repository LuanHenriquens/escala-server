using escala_server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using escala_server.Services.Impl;
using escala_server.Services;
using escala_server.Repositories.Impl;
using escala_server.Repositories;
using escala_server.Auxiliary.Security;
using escala_server.Auxiliary;
using escala_server.Auxiliary.Security.Impl;
using escala_server.Auxiliary.Security.Classes;
using Microsoft.Extensions.Options;
namespace escala_server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetValue<string>("ConnectionString")));

            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
            
            services.AddSingleton<Validator, Validator>();
            services.AddSingleton<IEncrypt, Encrypt>();
            services.AddScoped<IAccessManager, AccessManager>();
            
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ILoginService, LoginService>();
            
            services.AddScoped<IMemberRepository, MemberRepository>();

            services.AddMvc(option => option.EnableEndpointRouting = false);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            // Aciona a extensão que irá configurar o uso de
            // autenticação e autorização via tokens
            services.AddJwtSecurity(
                signingConfigurations, tokenConfigurations);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            // app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            // app.UseMvc();
        }
    }
}
