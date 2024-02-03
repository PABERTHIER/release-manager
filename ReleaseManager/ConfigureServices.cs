namespace ReleaseManager;

public static class ConfigureServices
{
    public static void AddWebUiServices(this IServiceCollection services)
    {
        services.AddSpaStaticFiles(options => options.RootPath = "Nuxt/dist");
        services.AddControllers();
        services.AddSingleton<IReleaseService, ReleaseService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public static void ConfigureNuxtApp(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAuthentication();
        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        app.UseSpaStaticFiles();

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "Nuxt";
            if (env.IsDevelopment())
            {
                // Launch development server for Nuxt
                try
                {
                    spa.UseNuxtDevelopmentServer();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        });
    }
}