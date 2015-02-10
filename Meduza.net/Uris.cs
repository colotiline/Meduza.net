using System;
using Meduza.net.Models.Api;

namespace Meduza.net {
	internal static class Uris {
		internal static Uri BaseV2 { 
			get { return new Uri("https://meduza.io/api/v2/"); }
		}
		internal static string Index {
			get { return "index"; }
		}
        internal static string IndexEn {
            get { return "index_en"; }
        }
	    internal static string GetIndex(Language language) {
	        return language == Language.Russian ? Index : IndexEn;
	    }
	}
}
