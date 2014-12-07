using System;

namespace Meduza.net {
	internal static class Uris {
		internal static Uri BaseV1 {
			get { return new Uri("https://meduza.io/api/v1/"); }
		}
		internal static Uri BaseV2 { 
			get { return new Uri("https://meduza.io/api/v2/"); }
		}
		internal static string Index {
			get { return "index"; }
		}
	}
}
