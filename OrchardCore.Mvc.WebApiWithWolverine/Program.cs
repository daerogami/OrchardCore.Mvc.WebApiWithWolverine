using Microsoft.OpenApi.Models;
using Oakton;
using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOrchardCore()
    .AddMvc()
     // Orchard Specific Pipeline
     .ConfigureServices( services => {
         services.AddEndpointsApiExplorer();
         services.AddSwaggerGen(c =>
         {
             c.EnableAnnotations();
             c.SwaggerDoc("v1", new OpenApiInfo
             {
                 Version = "1.0.0",
                 Title = "OrchardCore.Mvc.WebApiWothWolverine"
             });
         });
     })
     .Configure( (app, routes, services) => {
         // NOTE: This is where wolverine endpoints should be mapped, but the Lamar IoC isn't available here because IContainer is registered outside the tenant scope
         //routes.MapWolverineEndpoints();
         var env = app.ApplicationServices.GetService<IWebHostEnvironment>();
         env ??= app.ApplicationServices.GetService<IHostEnvironment>() as IWebHostEnvironment;

         if (env?.IsDevelopment() ?? false)
         {
             app.UseSwagger();
             app.UseSwaggerUI(c =>
             {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "An ASP.NET Core Web API");
             });
         }
     });

builder.Host.UseWolverine();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// NOTE: This is just here to demonstrate that wolverine endpoints lack access to services registered under the OrchardCore tenant, compare with the controllers implicity registered by OrchardCore
app.MapWolverineEndpoints();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseOrchardCore();

await app.RunOaktonCommands(args);
