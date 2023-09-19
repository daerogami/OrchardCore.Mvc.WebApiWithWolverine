using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOrchardCore()
    .AddMvc()
     // Orchard Specific Pipeline
     .ConfigureServices( services => {

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

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseOrchardCore();

app.Run();
