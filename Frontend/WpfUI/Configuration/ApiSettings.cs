using System;

namespace WpfUI.Configuration;

public class ApiSettings
{
    public const string SectionName = "ApiSettings";

    public string BaseUrl { get; set; } = string.Empty;

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(BaseUrl))
        {
            throw new InvalidOperationException("ApiSettings:BaseUrl configuration setting is missing or empty.");
        }

        if (!Uri.TryCreate(BaseUrl, UriKind.Absolute, out var uri) ||
            !(uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
        {
            throw new InvalidOperationException($"ApiSettings:BaseUrl '{BaseUrl}' is not a valid absolute HTTP or HTTPS URL.");
        }
    }
}
