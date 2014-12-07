﻿using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Meduza.net.Annotations;
using Meduza.net.Exceptions;
using Meduza.net.Models.Api;
using Meduza.net.Models.Api.Page;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Meduza.net {
	public sealed class Api : INotifyPropertyChanged {
		private readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler {
			AutomaticDecompression = DecompressionMethods.GZip
		}) {
			BaseAddress = Uris.BaseV2
		};
		private Main _main;
		public Api(bool defaultInitialization = true) {
			if (!(DefaultInitialization = defaultInitialization)) return;
			Initialize();
		}
		private async Task<Main> GetMainAsync() {
			var content = await _httpClient.GetStringAsync(Uris.Index);
			if (string.IsNullOrWhiteSpace(content)) throw new EmptyAnswerException("Meduza.io answer is empty");

			return JsonConvert.DeserializeObject<Main>(content);
		}
		private void Initialize() {
			_httpClient.GetStringAsync(Uris.Index).ContinueWith(task => {
				if (task.Exception != null) throw task.Exception;
				if (string.IsNullOrWhiteSpace(task.Result)) throw new EmptyAnswerException("Meduza.io answer is empty");

				Main = JsonConvert.DeserializeObject<Main>(task.Result);
			}).Wait();
		}

		public async Task<bool> InitializeAsync() {
			if (Main != null) return false;
			Main = await GetMainAsync();
			return true;
		}
		// ReSharper disable once UnusedMember.Global
		public async Task<bool> RefreshAsync() {
			Main = await GetMainAsync();
			return Main != null;
		}

		// ReSharper disable once MemberCanBePrivate.Global
		public bool DefaultInitialization { get; private set; }
		public Main Main {
			get { return _main; }
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

		private async Task<Document> LoadAsync(string uri) {
			var content = await _httpClient.GetStringAsync(uri);
			return JObject.Parse(content).GetValue(Root).ToObject<Document>();
		}

		public async Task<Document> LoadNewsAsync(string uri) {
			return await LoadAsync(uri);
		}
		public async Task<Topic> LoadTopicAsync(string uri) {
			var content = await _httpClient.GetStringAsync(uri);
			return JsonConvert.DeserializeObject<Topic>(content);
		}
		public async Task<Document> LoadArticleAsync(string uri) {
			return await LoadAsync(uri);
		}
		public async Task<Document> LoadFunAsync(string uri) {
			return await LoadAsync(uri);
		}
		public async Task<Document> LoadCardAsync(string uri) {
			var result = await LoadAsync(Uris.BaseV1 + uri); //Loading chapters
			return result;
		}
	}
}
