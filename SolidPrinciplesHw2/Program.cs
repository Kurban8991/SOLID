using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SolidPrinciplesHw2.NumberGenerator;
using SolidPrinciplesHw2.Settings;
using SolidPrinciplesHw2.Logger;

namespace SolidPrinciplesHw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", false);
            builder.Services.AddTransient<MyGenerator>();
            builder.Services.AddTransient<Logger.Logger, SinkConsoleLogger>();
            builder.Services.AddTransient<Worker>();
            builder.Services.Configure<GameRulesSetting>(builder.Configuration.GetSection(GameRulesSetting.GameRules));

            IHost host = builder.Build();
            host.Services.GetRequiredService<Worker>().Run();
        }
    }
}
