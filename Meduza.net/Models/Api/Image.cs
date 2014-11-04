using Newtonsoft.Json;

namespace Meduza.net.Models.Api {
	public sealed class Image {
		private readonly string _originalUri;
		private readonly string _largeUri;
		private readonly string _smallUri;
		private readonly string _caption;
		private readonly string _credit;
		public Image(
			[JsonProperty(PropertyName = "original_url")] string originalUri,
			[JsonProperty(PropertyName = "large_url")] string largeUri,
			[JsonProperty(PropertyName = "small_url")] string smallUri,
			string caption,
			string credit) {
			_originalUri = originalUri;
			_largeUri = largeUri;
			_smallUri = smallUri;
			_caption = caption;
			_credit = credit;
		}
		public string OriginalUri {
			get { return _originalUri; }
		}
		public string LargeUri {
			get { return _largeUri; }
		}
		public string SmallUri {
			get { return _smallUri; }
		}
		public string Caption {
			get { return _caption; }
		}
		public string Credit {
			get { return _credit; }
		}
	}
}
