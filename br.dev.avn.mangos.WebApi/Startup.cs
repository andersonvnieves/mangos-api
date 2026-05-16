using Amazon.DynamoDBv2;
using br.dev.avn.mangos.Application.Repositories;
using br.dev.avn.mangos.Application.UseCases.CreditCard;
using br.dev.avn.mangos.Infrastructure.Persistence.DynamoDB.Repositories;

namespace br.dev.avn.mangos.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            services.AddSingleton<IAmazonDynamoDB>(_ => {
                var config = new AmazonDynamoDBConfig
                    {
                        ServiceURL = Configuration["DynamoDB:ServiceUrl"],
                    };
                return new AmazonDynamoDBClient("local","local",config);
            });
        }
        else
        {
            services.AddSingleton<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient());
        }
        //Repositories
        services.AddScoped<ILedgerRepository, DynamoLedgerRepository>();
        
        //UseCases
        services.AddScoped<RegisterCCTRansactionUseCase>();
        
        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/",
                async context =>
                {
                    await context.Response.WriteAsync("Mangos API");
                });
        });
    }
}