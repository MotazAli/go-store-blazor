using GoStore.Data;
using GoStore.Data.Database;
using GoStore.Repositories.Implmentations;
using GoStore.Repositories.Interfaces;
using GoStore.Services;
using GoStore.Services.Implementations;
using GoStore.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Go Store Web Api v1");
        c.RoutePrefix = "api/swagger";
    });
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();// using controllers for using that Blazor Server as Web API too
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


//-------------------------------------------------------------



static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddDbContext<GoStoreDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    AddDependancyInjectionServices(services);
}




// Add services to the container.
static void AddDependancyInjectionServices(IServiceCollection services) 
{

    //getting the controllers from GoStore.Controllers Libarary
    services.AddControllers(options => { options.SuppressAsyncSuffixInActionNames = false; })
        .AddApplicationPart(Assembly.Load(new AssemblyName("GoStore.Controllers")));
    services.AddRazorPages();
    services.AddServerSideBlazor();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Go Store Web Api v1", Version = "v1" });
    });

    //services.AddScoped<ICartService, CartService>();
    services.AddTransient<IUnitOfWork, UnitOfWork>();
    //services.AddTransient<IProductService, ProductService>();
    services.AddTransient<ICategoryService, CategoryService>();
}
