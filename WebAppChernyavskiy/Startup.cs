using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppChernyavskiy.Models.Account;
using WebAppChernyavskiy.Models.Collections;

namespace WebAppChernyavskiy {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<UserContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("AccountConnection")));
            services.AddDbContext<CollectionContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CollectionConnection")));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>();

            services.AddAuthentication().AddGoogle(options => {
                options.ClientId = "199568271462-uiemi1meje3ppg1lb4d86vc8bhj6f5l2.apps.googleusercontent.com";
                options.ClientSecret = "Gg40Ht_WgAbvDNnTVXWUIg3u";
            }).AddMicrosoftAccount(microsoftOptions => {
                microsoftOptions.ClientId = "fd26b240-ca72-41f8-80d1-304531721a98";
                microsoftOptions.ClientSecret = "/9xU9byJC2R6dms@.IUjsNPI@?qF/Ezl";
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
