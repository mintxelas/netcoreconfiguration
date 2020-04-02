using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationInjection
{
    public class ExternalApiConfiguration
    {
        public string BaseUrl { get; set; }
        public string AuthorizationServer { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

    }
}
