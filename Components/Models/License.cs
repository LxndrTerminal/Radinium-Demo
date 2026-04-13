using System.ComponentModel.DataAnnotations;

namespace BlazorHelloWorld.Components.Models
{
    public class License
   {
	[Required]
        public string productId { get; set; }
	public string? id { get; set; }
	public string? key { get; set; }
    }
}
