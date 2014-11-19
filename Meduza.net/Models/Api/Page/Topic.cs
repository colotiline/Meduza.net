using System.Collections.Generic;

namespace Meduza.net.Models.Api.Page {
	public sealed class Topic {
		private readonly Root _root;
		private readonly Dictionary<string, Document> _documents;
		public Topic(
			Root root,
			Dictionary<string, Document> documents) {
			_root = root;
			_documents = documents;
		}
		public Root Root {
			get { return _root; }
		}
		public Dictionary<string, Document> Documents {
			get { return _documents; }
		}
	}
}
