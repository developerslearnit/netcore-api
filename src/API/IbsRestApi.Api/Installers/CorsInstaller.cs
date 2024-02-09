namespace IbsRestApi.Api.Installers;

public class CorsInstaller : IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("IbsCorsPolicy", builder =>

              builder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader());
        });
    }
}
