using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace IbsRestApi.Api.Installers;

public class SwaggerInstaller : IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ibs Investment API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { new OpenApiSecurityScheme{Reference=new OpenApiReference{
                    Id="Bearer",
                    Type = ReferenceType.SecurityScheme

                }},new List<string>() }

            });
            c.OperationFilter<AppSwaggerCustomheaderAttribute>();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            c.IncludeXmlComments(xmlPath);
        });
    }
}


public class AppSwaggerCustomheaderAttribute : IOperationFilter
{


    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "x-iMoneytor-auth",
            In = ParameterLocation.Header,
            Required = true,
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });


        //var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

        //if (descriptor != null && (descriptor.ControllerName.EndsWith("Controller")))
        //{
        //    operation.Parameters.Add(new OpenApiParameter
        //    {
        //        Name = "x-iMoneytor-auth",
        //        In = ParameterLocation.Header,
        //        Required = true,
        //        Schema = new OpenApiSchema
        //        {
        //            Type = "string"
        //        }
        //    });
        //}
    }
}

