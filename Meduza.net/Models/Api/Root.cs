using System;
using System.Collections.Generic;
using Meduza.net.Helpers;
using Meduza.net.Models.Api.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meduza.net.Models.Api {
	public sealed class Root {
		private readonly string _title;
		private readonly ScreenType _screenType;
		private readonly IReadOnlyList<string> _collection;
		private readonly DateTime _updatedAt;
		public Root(
			string title, 
			
			[JsonProperty(PropertyName = "screen_type")] 
			[JsonConverter(typeof(StringEnumConverter))]
			ScreenType screenType,

			IReadOnlyList<string> collection,
			
			[JsonProperty(PropertyName = "updated_at")]
			[JsonConverter(typeof(UnixDateTimeConverter))] DateTime updatedAt) {
			_title = title;
			_screenType = screenType;
			_collection = collection;
			_updatedAt = updatedAt;
		}
		public string Title {
			get { return _title; }
		}
		public ScreenType ScreenType {
			get { return _screenType; }
		}
		public IReadOnlyList<string> Collection {
			get { return _collection; }
		}
		public DateTime UpdatedAt {
			get { return _updatedAt; }
		}
		public string Main { get; set; }
	}
}
