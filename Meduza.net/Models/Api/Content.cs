using Newtonsoft.Json;

namespace Meduza.net.Models.Api {
	public sealed class Content {
		public string Body { get; set; }
		
		[JsonProperty(PropertyName = "layout_url")] 
		public string LayoutUri { get; set; }
	}
}
