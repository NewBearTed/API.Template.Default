using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace API.Template.Default.Extensions.HealthChecks
{
    public static class HealthChecksBuilderExtension
    {
        public static IHealthChecksBuilder AddHealthChecksSystem(this IHealthChecksBuilder healthChecksBuilder)
        {
            var currentMemory = Process.GetCurrentProcess().PrivateMemorySize64;
            var maximumMemory = currentMemory - 104857600;

            healthChecksBuilder.AddDiskStorageHealthCheck(setup: (diskStorageOptions) =>
             {
                 diskStorageOptions.AddDrive(@"C:\", minimumFreeMegabytes: 9000);
             }, "My Drive", HealthStatus.Degraded)
             .AddPrivateMemoryHealthCheck(maximumMemoryBytes: maximumMemory, "My Memory", HealthStatus.Degraded)
             .AddVirtualMemorySizeHealthCheck(maximumMemoryBytes: maximumMemory, "My Virtual Memory");

            return healthChecksBuilder;
        }
    }
}
