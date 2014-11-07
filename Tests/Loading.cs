using System.Linq;
using Meduza.net;
using Meduza.net.Models.Api.Enum;
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
			var uri = api.Main.Root.First(r => r.ScreenType == ScreenType.News).Collection.First();
			var document = await api.LoadNewsAsync(uri);

			Assert.NotNull(document);
		}
		[Test]
		public async void LoadTopic() {
			var api = new Api();
			var uri = api.Main.Root.First(r => r.ScreenType == ScreenType.Topic).Collection.First();
			var document = await api.LoadTopicAsync(uri);

			Assert.NotNull(document);
		}
		[Test]
		public async void LoadArticle() {
			var api = new Api();
			var uri = api.Main.Root.First(r => r.ScreenType == ScreenType.Articles).Collection.First();
			var document = await api.LoadArticleAsync(uri);

			Assert.NotNull(document);
		}
		[Test]
		public async void LoadFun() {
			var api = new Api();
			var uri = api.Main.Root.First(r => r.ScreenType == ScreenType.Fun).Collection.First();
			var document = await api.LoadFunAsync(uri);

			Assert.NotNull(document);
		}
	}
}
