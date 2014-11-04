using System;

namespace Meduza.net {
	internal static class Uris {
		internal static Uri Main { 
			get { return new Uri("https://meduza.io/api/v1/"); }
		}
		internal static string Index {
			get { return "index"; }
		}
	}
}
