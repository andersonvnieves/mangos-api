using Amazon.DynamoDBv2;
using br.dev.avn.mangos.Application.Repositories;
using br.dev.avn.mangos.Application.UseCases.CreditCard;
using br.dev.avn.mangos.Application.UseCases.CreditCard.ListRecentTransactions;
using br.dev.avn.mangos.Application.UseCases.CreditCard.RetrieveCCTransaction;
using br.dev.avn.mangos.Infrastructure.Persistence.DynamoDB.Repositories;

namespace br.dev.avn.mangos.WebApi;

public class Startup
{
    public IWebHostEnvironment Environment { get; }
    
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        Environment = env;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        //Console.WriteLine(Configuration["DynamoDB:ServiceUrl"]);
        if (Environment.IsDevelopment())
        {
            services.AddSingleton<IAmazonDynamoDB>(_ => {
                var config = new AmazonDynamoDBConfig
                    {
                        ServiceURL = "http://localhost:8000",
                    };
                return new AmazonDynamoDBClient(config);
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
        services.AddScoped<RetrieveCCTransactionUseCase>();
        services.AddScoped<ListRecentTransactionsUseCase>();
        
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
                    await context.Response.WriteAsync("Mangos API is in healthy state");
                });
        });
    }
}