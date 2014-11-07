using Newtonsoft.Json;

namespace Meduza.net.Models.Api {
	public sealed class Content {
		private readonly string _body;
		private readonly string _layoutUri;
		private readonly string _description;
		public Content(
			string body,
			[JsonProperty(PropertyName = "layout_url")] string layoutUri,
			string description) {
			_body = body;
			_layoutUri = layoutUri;
			_description = description;
		}
		public string Body {
			get { return _body; }
		}
		public string LayoutUri {
			get { return _layoutUri; }
		}
		public string Description {
			get { return _description; }
		}
	}
}
