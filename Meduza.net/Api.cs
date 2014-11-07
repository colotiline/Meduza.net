using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Meduza.net.Annotations;
using Meduza.net.Models.Api;
using Meduza.net.Models.Api.Enum;
using Meduza.net.Models.Api.Page;
using Meduza.net.Models.Api.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Meduza.net {
	public sealed class Api : INotifyPropertyChanged {
		private readonly HttpClient _httpClient = new HttpClient (new HttpClientHandler {
			AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
		}) {
			BaseAddress = Uris.Main
		};
		private Main _main;
		public Api(bool defaultInitialization = true) {
			if (!(DefaultInitialization = defaultInitialization)) return;
			Initialize();
		}
		private async Task<Main> GetMainAsync() {
			return JsonConvert.DeserializeObject<Main>(await _httpClient.GetStringAsync(Uris.Index));
		}
		private void Initialize() {
			_httpClient.GetStringAsync(Uris.Index).ContinueWith(task => {
				Main = JsonConvert.DeserializeObject<Main>(task.Result);
			}).Wait();
		}

		public async Task<bool> InitializeAsync() {
			if (Main != null) return false;
			Main = await GetMainAsync();
			return true;
		}		
		public async void RefreshAsync() {
			Main = await GetMainAsync();
		} 

		public bool DefaultInitialization { get; set; }
		public Main Main {
			get { return _main;  }
			private set {
				_main = value;
				OnPropertyChanged();
			}
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

		//Loading full articles
		private const string Root = "root";

		private async Task<News> LoadAsync(string uri) {
			var content = await _httpClient.GetStringAsync(uri);
			return JObject.Parse(content).GetValue(Root).ToObject<News>();
		}

		public async Task<News> LoadNewsAsync(string uri) {
			return await LoadAsync(uri);
		}
		public async Task<Document> LoadTopicAsync(string uri) {
			var content = await _httpClient.GetStringAsync(uri);
			return JObject.Parse(content).GetValue(Root).ToObject<Document>();
		}
		public async Task<News> LoadArticleAsync(string uri) {
			return await LoadAsync(uri);
		}
		public async Task<News> LoadFunAsync(string uri) {
			return await LoadAsync(uri);
		}
		public async Task<News> LoadCardAsync(string uri) {
			return await LoadAsync(uri);
		}	
	}
}
