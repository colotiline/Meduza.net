using System;
using Meduza.net.Models.Api;

namespace Meduza.net {
	internal static class Uris {
		internal static Uri Base { 
			get { return new Uri("https://meduza.io/api/v3/"); }
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
