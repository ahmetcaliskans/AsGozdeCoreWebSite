using AsGozdeCoreWebSite.Models.PermissionAuthorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using SaveDashboardDB;
using Core.Utilities.IoC;
using Core.Extensions;
using Core.DependencyResolvers;
using DevExpress.AspNetCore.Reporting;
using DevExpress.XtraReports.Web.Extensions;

namespace AsGozdeCoreWebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            FileProvider = hostingEnvironment.ContentRootFileProvider;
            DashboardExportSettings.CompatibilityMode = DashboardExportCompatibilityMode.Restricted;
        }

        public IFileProvider FileProvider { get; }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {           

            services.AddControllersWithViews();

            services.AddSession();               

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new CultureInfo[] { new CultureInfo("tr-TR") };
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
                options.DefaultRequestCulture = new RequestCulture("tr-TR");
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });


            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Permission", policyBuilder =>
                {
                    policyBuilder.Requirements.Add(new PermissionAuthorizationRequirement());
                });
            });

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/";
            });


            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(1);

                options.LoginPath = "/Login/Index";
                options.SlidingExpiration = true;

            });

            

            // Configures services to use the Web Dashboard Control.
            services
                .AddDevExpressControls()
                .AddControllersWithViews();
            services.AddScoped<DashboardConfigurator>((System.IServiceProvider serviceProvider) => {
                
                DashboardConfigurator configurator = new DashboardConfigurator();
                configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(Configuration));

                var dataBaseDashboardStorage = new DataBaseEditaleDashboardStorage(
                    Configuration.GetConnectionString("AsGozdeDatabase"));
                configurator.SetDashboardStorage(dataBaseDashboardStorage);

                DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
                configurator.SetDataSourceStorage(dataSourceStorage);

                configurator.ConfigureDataReloadingTimeout += (s, e) => { e.DataReloadingTimeout = TimeSpan.FromSeconds(5); };


                return configurator;
            });

            services.AddDevExpressControls();
            //services.AddScoped<ReportStorageWebExtension, CustomReportStorageWebExtension>();
            services
                .AddMvc()
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
            services.ConfigureReportingServices(configurator => {
                configurator.ConfigureReportDesigner(designerConfigurator => {
                    designerConfigurator.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
                });
                configurator.ConfigureWebDocumentViewer(viewerConfigurator => {
                    viewerConfigurator.UseCachedReportSourceBuilder();
                });
            });

            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRequestLocalization();

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;
            app.UseDevExpressControls();

            app.UseEndpoints(endpoints =>
            {
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "dashboardControl", "DefaultDashboard");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });            

        }
    }
}
