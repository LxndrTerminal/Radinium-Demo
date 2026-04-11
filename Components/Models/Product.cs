using System.ComponentModel.DataAnnotations;


namespace BlazorHelloWorld.Components.Models
{
    public class Product
    {
	[Required]
        public string description { get; set; }
        [Required]
	public string displayName { get; set; }
	public string licenseTemplateId { get; set; }
	[Required]
	public string name { get; set; }
    }
}
