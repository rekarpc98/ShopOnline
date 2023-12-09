using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopOnline.Web;
using ShopOnline.Web.Models.Configurations;
using ShopOnline.Web.Repositories.Implementations;
using ShopOnline.Web.Repositories.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress =
	builder.Configuration.GetRequiredSection(nameof(ApiConfiguration.SectionName)).Get<ApiConfiguration>()!;

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress.BaseUrl) });

builder.Services.AddScoped<IProductRepository, ProductRepository>();

await builder.Build().RunAsync();