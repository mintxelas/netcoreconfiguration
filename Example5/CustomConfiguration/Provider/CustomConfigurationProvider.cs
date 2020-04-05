using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;

namespace CustomConfiguration.Provider
{
    public class CustomConfigurationProvider : IConfigurationProvider
    {
        private readonly string connectionString;
        private Dictionary<string, string> dbParams = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public CustomConfigurationProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
        {
            if (string.IsNullOrWhiteSpace(parentPath))
                return dbParams.Keys;
            return new string[] { };
        }

        public IChangeToken GetReloadToken()
        {
            return new CancellationChangeToken(new CancellationToken(false));
        }

        public void Load()
        {
            var q = SqlMapper.Query<dynamic>(new SqlConnection(connectionString), "select name,value from parameters");
            foreach(var item in q)
            {
                dbParams.Add(item.name, item.value);
            }
        }

        public void Set(string key, string value)
        {
            dbParams[key] = value;
        }

        public bool TryGet(string key, out string value)
        {
            return dbParams.TryGetValue(key, out value);
        }
    }
}
