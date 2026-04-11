using System.ComponentModel.DataAnnotations;

namespace BlazorHelloWorld.Components.Models
{
public class LicenseTemplate
    {
	[Required]
	public string id { get; set; }
	[Required]
	public string name { get; set; }
    }
}
