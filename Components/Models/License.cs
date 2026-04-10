using System.ComponentModel.DataAnnotations;

namespace BlazorHelloWorld.Components.Models
{
    public class License
    {
	[Required]
        public int productId { get; set; }
    }
}
