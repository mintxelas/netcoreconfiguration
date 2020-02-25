using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomConfiguration.Provider
{
    public class CustomConfigurationSource : IConfigurationSource
    {
        private readonly string connectionString;

        public CustomConfigurationSource(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new CustomConfigurationProvider(connectionString);
        }
    }
}
