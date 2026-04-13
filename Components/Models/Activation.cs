using System.ComponentModel.DataAnnotations;


namespace BlazorHelloWorld.Components.Models
{
    public class Activation
    {
	public string id { get; set; }
	public string hostname {get; set; }
        public string createdAt { get; set; }
        public string licenseId { get; set;}
	public string os { get; set; }
	public string productId { get; set; }
    }
}
