using Newtonsoft.Json;

namespace Meduza.net.Models.Api {
	public sealed class Source {
		[JsonProperty(PropertyName = "url")] 
		public string Uri { get; set; }

		public string Name { get; set; }
		public string Quote { get; set; }
	}
}
