using API.Standard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public Startup(IConfiguration config)
    {
        Configuration = config;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureApi(Configuration, typeof(Startup));
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.ConfigureApi(env);
    }
}