using Destructurama;

using Microsoft.AspNetCore.Builder;

using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.Destructurers;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using Serilog.Exceptions.SqlServer.Destructurers;
using Serilog.Formatting.Compact;

namespace Logging;

public static class Extensions
{
    public static void UseRequestLogging(this WebApplication app)
    {
        app.UseSerilogRequestLogging(options =>
        {
            options.GetLevel += (context, elapsed, ex) =>
                ex is not null || context?.Response.StatusCode >= 500
                    ? LogEventLevel.Error
                    : context?.Response.StatusCode >= 400
                        ? LogEventLevel.Warning
                        : elapsed > TimeSpan.FromSeconds(30).TotalMilliseconds
                            ? LogEventLevel.Warning
                            : LogEventLevel.Debug;
        });
    }

    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        var destructurers = new IExceptionDestructurer[]
            { new DbUpdateExceptionDestructurer(), new SqlExceptionDestructurer() };

        builder.Host
            .UseSerilog((context, services, configuration) =>
            {
                configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Destructure.UsingAttributes()
                    .WriteTo.Console(new RenderedCompactJsonFormatter())
                    .Enrich.FromLogContext()
                    .Enrich.WithThreadId()
                    .Enrich.WithThreadName()
                    .Enrich.WithCorrelationId()
                    .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                        .WithDefaultDestructurers()
                        .WithDestructurers(destructurers)
                        .WithIgnoreStackTraceAndTargetSiteExceptionFilter());
            });
    }
}