namespace Meduza.net.Models.Api.Card {
	public sealed class Chapter {
		private readonly string _title;
		private readonly string _content;
		public Chapter(
			string title,
			string content) {
			_title = title;
			_content = content;
		}
		public string Title {
			get { return _title; }
		}
		public string Content {
			get { return _content; }
		}
	}
}
