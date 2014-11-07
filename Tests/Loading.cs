using System.Linq;
using Meduza.net;
using NUnit.Framework;

namespace Tests {
	[TestFixture]
	internal sealed class Loading {
		[Test]
		public void DefaultInitialization() {
			var api = new Api();
			
			Assert.NotNull(api.Main);
		}
		[Test]
		public async void NonDefaultInitialization() {
			var api = new Api(false);
			Assert.IsNull(api.Main);

			await api.InitializeAsync();		
			Assert.NotNull(api.Main);
		}
		[Test]
		public async void LoadNews() {
			var api = new Api();
			
			var document = api.Main.Documents.First();
			var fullDocument = await api.LoadNewsAsync(document.Value.Uri);

			Assert.NotNull(fullDocument);
		}
	}
}
