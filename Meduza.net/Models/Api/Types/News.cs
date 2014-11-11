using System;
using System.Collections.Generic;
using Meduza.net.Helpers;
using Meduza.net.Models.Api.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meduza.net.Models.Api.Types {
	public sealed class News : Document {
		public News(
			[JsonProperty(PropertyName = "url")] string uri,
			string title,
			[JsonProperty(PropertyName = "second_title")] string secondTitle,
			IReadOnlyList<IReadOnlyList<string>> authors,

			[JsonProperty(PropertyName = "document_type")] 
			[JsonConverter(typeof(StringEnumConverter))]
			DocumentType documentType,

			int version,
			[JsonProperty(PropertyName = "published_at")]
			[JsonConverter(typeof(UnixDateTimeConverter))] DateTime publishedAt,

			[JsonProperty(PropertyName = "updated_at")]
			[JsonConverter(typeof(UnixDateTimeConverter))] DateTime updatedAt,

			[JsonProperty(PropertyName = "full")] bool isFull,
			Source source,
			Image image)
			: base(
			uri, 
			title, 
			secondTitle, 
			authors, 
			documentType, 
			version, 
			publishedAt, 
			updatedAt, 
			isFull, 
			source, 
			image) { }
		[JsonProperty(PropertyName = "Content")]
		public Content Contents { get; set; }
	}
}
