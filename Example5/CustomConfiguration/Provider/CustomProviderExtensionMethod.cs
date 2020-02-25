using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomConfiguration.Provider
{
    public static class CustomProviderExtensionMethod
    {
        public static IConfigurationBuilder AddCustomProvider(this IConfigurationBuilder builder, string connectionString)
        {
            return builder.Add(new CustomConfigurationSource(connectionString));
        }
    }
}
