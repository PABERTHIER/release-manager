WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddWebUiServices();

WebApplication app = builder.Build();

ConfigureServices.ConfigureNuxtApp(app, builder.Environment);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

app.WaitForShutdown();
