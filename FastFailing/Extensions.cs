using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FastFailing;

public static class Extensions
{
    public static void AddFastFailing(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<FailFastTask>().TryAddSingleton(builder.Services);
    }

    public static void RunWithFastFailing(this WebApplication app)
    {
        var failFastTask = app.Services.GetService<FailFastTask>() ??
                           throw new InvalidOperationException("FailFastTask has not been registered.");

        failFastTask.Execute();

        app.Run();
    }
}