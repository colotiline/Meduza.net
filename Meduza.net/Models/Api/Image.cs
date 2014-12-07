using Newtonsoft.Json;

namespace Meduza.net.Models.Api {
	public sealed class Image {
		[JsonProperty(PropertyName = "original_url")] 
		public string OriginalUri { get; set; }

		[JsonProperty(PropertyName = "large_url")] 
		public string LargeUri { get; set; }

		[JsonProperty(PropertyName = "small_url")] 
		public string SmallUri { get; set; }

		public string Caption { get; set; }
		public string Credit { get; set; }
	}
}
