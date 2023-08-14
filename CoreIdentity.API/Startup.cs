using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;
using CoreIdentity.Persistence;
using CoreIdentity.Application;

namespace CoreIdentity.API;

public class Startup
{
    private ILoggerFactory _loggerFactory;

    public Startup(IConfiguration configuration)
    {
        _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole().SetMinimumLevel(LogLevel.Information);
        });

        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization();
        var logger = _loggerFactory.CreateLogger(typeof(Startup));

        // print all configurations here


        //then reset the logger after printing
        _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole().SetMinimumLevel(LogLevel.Information);
        });
        logger = _loggerFactory.CreateLogger(typeof(Startup));

        // Service Layers 
        string connString = Configuration.GetConnectionString("CoreIdentityDb");
        services.AddPersistenceLayer(connString);
        services.AddApplicationLayer();

        //services.AddControllers(opts => opts.Filters.Add(new AuthorizeFilter()));
        services.AddControllers();

        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        services.AddSwaggerGen(opts =>
        {
            opts.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreIdentity API", Version = "version 1.0" });
            opts.SwaggerDoc("v2", new OpenApiInfo { Title = "CoreIdentity API", Version = "version 2.0" });

            //opts.OperationFilter<FileUploadOperation>();
            //opts.OperationFilter<OptionalRouteParameterOperationFilter>();
            opts.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                        },
                        new[] { "CoreIdentity", "CoreIdentity" }
                    }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            opts.IncludeXmlComments(xmlPath);
        });

        services.AddMemoryCache();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHttpsRedirection();
        }

        app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");
        app.UseSwaggerUI();

        app.UseRouting();

        app.UseAuthentication();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
