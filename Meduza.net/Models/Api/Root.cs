using System;
using System.Collections.Generic;
using Meduza.net.Helpers;
using Meduza.net.Models.Api.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meduza.net.Models.Api {
	public sealed class Root {
		public string Title { get; set; }

		[JsonProperty(PropertyName = "screen_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ScreenType ScreenType { get; set; }

		public IReadOnlyList<string> Collection { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		[JsonConverter(typeof(UnixDateTimeConverter))] 
		public DateTime UpdatedAt { get; set; }
	}
}
