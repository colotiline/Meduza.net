using Newtonsoft.Json;

namespace Meduza.net.Models.Api {
	public sealed class Gallery {
		public int Id { get; set; }

		[JsonProperty(PropertyName = "original_url")]
		public string OriginalUri { get; set; }

		[JsonProperty(PropertyName = "large_url")]
		public string LargeUri { get; set; }

		[JsonProperty(PropertyName = "small_url")]
		public string SmallUri { get; set; }

		[JsonProperty(PropertyName = "large_width")]
		public string LargeWidth { get; set; }

		[JsonProperty(PropertyName = "large_height")]
		public string LargeHeight { get; set; }

		public string Caption { get; set; }
		public string Credit { get; set; }
		public string Text { get; set; }
	}
}

