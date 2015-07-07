using System.ComponentModel;
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
        private readonly Language _language;
        private Main _main;

        private readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        }) {
            BaseAddress = Uris.Base
        };
        public Api(Language language, bool defaultInitialization = true) {
            _language = language;
            if (!(DefaultInitialization = defaultInitialization)) return;
            Initialize();
        }
        private async Task<Main> GetMainAsync() {
            var content = await _httpClient.GetStringAsync(Uris.GetIndex(_language));
            if (string.IsNullOrWhiteSpace(content)) throw new EmptyAnswerException("Meduza.io answer is empty");

            return JsonConvert.DeserializeObject<Main>(content);
        }
        private void Initialize() {
            _httpClient.GetStringAsync(Uris.GetIndex(_language)).ContinueWith(task => {
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

        public async Task<Document> LoadAsync(string uri) {
            var content = await _httpClient.GetStringAsync(uri);
            return JObject.Parse(content).GetValue(Root).ToObject<Document>();
        }
    }
}
