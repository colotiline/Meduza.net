using System.Collections.Generic;

namespace Meduza.net.Models.Api.Page {
	public sealed class Main {
		public IReadOnlyList<Root> Root { get; set; }
		public Dictionary<string, Document> Documents { get; set; }
	}
}
