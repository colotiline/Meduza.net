using System.Collections.Generic;

namespace Meduza.net.Models.Api.Page {
	public sealed class Main {
		private readonly IReadOnlyList<Root> _root;
		private readonly Dictionary<string, Document> _documents;
		public Main(
			IReadOnlyList<Root> root,
			Dictionary<string, Document> documents) {
			_root = root;
			_documents = documents;
		}
		public IReadOnlyList<Root> Root {
			get { return _root; }
		}
		public Dictionary<string, Document> Documents {
			get { return _documents; }
		}
	}
}
