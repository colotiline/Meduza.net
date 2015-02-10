using System.Linq;
using Meduza.net.Models.Api;
using Meduza.net.Models.Api.Enum;
using NUnit.Framework;

namespace Tests.Api {
	[TestFixture]
	internal sealed class English {
	    private Meduza.net.Api _api;
	    
        [SetUp]
	    public void Init() {
	        _api = new Meduza.net.Api(Language.English);
	    }
		[Test]
		public void DefaultInitialization() {
			Assert.NotNull(_api.Main);
		}
		[Test]
		public async void NonDefaultInitialization() {
			var api = new Meduza.net.Api(Language.English, false);
			Assert.IsNull(api.Main);

			await api.InitializeAsync();
			Assert.NotNull(api.Main);
		}
		[Test]
		public async void LoadNews() {
			var uri = _api.Main.Root.First(r => r.ScreenType == ScreenType.News).Collection.First();
			var document = await _api.LoadAsync(uri);

			Assert.NotNull(document);
		}
		[Test]
		public async void LoadArticle() {
			var uri = _api.Main.Root.First(r => r.ScreenType == ScreenType.Articles).Collection.First();
			var document = await _api.LoadAsync(uri);

			Assert.NotNull(document);
		}
		[Test]
		public async void LoadFun() {
			var uri = _api.Main.Root.First(r => r.ScreenType == ScreenType.Fun).Collection.First();
			var document = await _api.LoadAsync(uri);

			Assert.NotNull(document);
		}
		[Test]
		public async void LoadGallery() {
			var uri = _api.Main.Documents.First(r => r.Value.DocumentType == DocumentType.Gallery).Key;
			var document = await _api.LoadAsync(uri);

			Assert.NotNull(document);

		}
	}
}
