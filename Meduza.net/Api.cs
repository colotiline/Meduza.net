using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Meduza.net.Annotations;
using Meduza.net.Models.Api.Page;
using Newtonsoft.Json;

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
	}
}
