using System;

namespace ValidateCustomConfiguration
{
    public class ExternalApiConfiguration: IValidateConfiguration
    {
        public string BaseUrl { get; set; }
        public string AuthorizationServer { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public void Validate()
        {
            if (!Uri.TryCreate(BaseUrl, UriKind.Absolute, out _))
            {
                throw new InvalidCastException("BaseUrl must point to a valid url.");
            }

            if (!Uri.TryCreate(AuthorizationServer, UriKind.Absolute, out _))
            {
                throw new InvalidCastException("AuthorizationServer must point to a valid url.");
            }
        }
    }

    public class AnotherConfigurationClass : ExternalApiConfiguration { }
}
