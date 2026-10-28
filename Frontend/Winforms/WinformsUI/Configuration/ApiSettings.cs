using System.ComponentModel.DataAnnotations;

namespace WinformsUI.Configuration;

public class ApiSettings
{
    public const string SectionName = "ApiSettings";

    [Required(ErrorMessage = "ApiSettings:BaseUrl is required.")]
    [Url(ErrorMessage = "ApiSettings:BaseUrl must be a valid HTTP/HTTPS URL.")]
    public string BaseUrl { get; set; } = string.Empty;
}
