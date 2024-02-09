namespace IbsRestApi.Api.Installers;

public class ControllerInstaller : IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {

        builder.Services.AddMemoryCache();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers
            (config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
    }
}
