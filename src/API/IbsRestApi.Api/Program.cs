using Hangfire;
using IbsRestApi.Api.Extensions;
using IbsRestApi.Api.Helpers;
using IbsRestApi.Api.Installers;
using IbsRestApi.Application.CommonModels;
using IbsRestApi.Common;
using IbsRestApi.Entities.IbsMdm;
using IbsRestApi.Persistence;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<SecureContext>(options =>
              options.UseSqlServer(builder.Configuration.GetSection("DBConnections:SecureConnection").Value,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                        );
                }));



builder.InstallServicesInAssembly();
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
builder.Services.AddIdentity<OnlineUserAccount, IbsTitle>().AddDefaultTokenProviders();


builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetSection("DBConnections:CronJobConnection").Value));
builder.Services.AddHangfireServer();

var app = builder.Build();

AppConfigSettings.AppSettingsConfigure(app.Services.GetRequiredService<IConfiguration>());

//app.UseGlobalException(app.Logger);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("IbsCorsPolicy");
app.UseForwardedHeaders(
    new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    });
string imageFolder = builder.Configuration.GetValue<string>("ImageFolder");

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @$"{imageFolder}")),
    RequestPath = new PathString($"/{imageFolder}")
});

app.UseOwaspConfig();

app.UseRouting();

app.UseHangfireDashboard("/cron/jobs");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "areas",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
     );
    endpoints.MapControllers();
});

app.Run();
