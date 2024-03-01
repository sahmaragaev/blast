using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Monitoring.Attributes;
using Prometheus;
using Utility;

namespace Monitoring;

public static class Extensions
{
    public static void AddMetricReporters(this WebApplicationBuilder builder)
    {
        Assembly assembly = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException("Cannot work in unmanaged application!");

        IEnumerable<Type> types = assembly.GetTypesByAttribute<MetricReporterAttribute>();

        foreach (Type type in types)
        {
            builder.Services.AddSingleton(type);
        }
    }

    public static void AddHealthChecks(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks().ForwardToPrometheus(new PrometheusHealthCheckPublisherOptions());
    }

    public static void UseMonitoring(this WebApplication app)
    {
        app.UseHealthChecks("/healthcheck");

        app.UseHttpMetrics(o =>
        {
            o.ReduceStatusCodeCardinality();
            o.ConfigureMeasurements(c => c.ExemplarPredicate = context => context.Response.StatusCode != (int)HttpStatusCode.OK);
        });

        app.MapMetrics();
    }
}