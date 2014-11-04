using Newtonsoft.Json;

namespace Meduza.net.Models.Api {
	public sealed class Source {
		private readonly string _uri;
		private readonly string _name;
		private readonly string _quote;
		public Source(
			[JsonProperty(PropertyName = "url")] string uri,
			string name,
			string quote) {
			_uri = uri;
			_name = name;
			_quote = quote;
		}
		public string Uri {
			get { return _uri; }
		}
		public string Name {
			get { return _name; }
		}
		public string Quote {
			get { return _quote; }
		}
	}
}
