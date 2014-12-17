using System;
using System.Collections.Generic;
using Meduza.net.Helpers;
using Meduza.net.Models.Api.Card;
using Meduza.net.Models.Api.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meduza.net.Models.Api {
	public class Document {
		[JsonProperty(PropertyName = "url")]
		public string Uri { get; set; }

		public string Title { get; set; }
		public List<List<string>> Authors { get; set; }

		[JsonProperty(PropertyName = "document_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public DocumentType DocumentType { get; set; }

		public int Version { get; set; }

		[JsonProperty(PropertyName = "published_at")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime PublishedAt { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "full")]
		public bool IsFull { get; set; }

		public Source Source { get; set; }
		public Image Image { get; set; }

		public Content Content { get; set; }

		public List<string> Related { get; set; }

		//Card properties
		[JsonProperty(PropertyName = "chapters_count")]
		public int ChaptersQuantity { get; set; }

		[JsonProperty(PropertyName = "table_of_contents")]
		public List<string> TableOfContents { get; set; }

		public string Thesis { get; set; }

		[JsonProperty(PropertyName = "layout_url")]
		public string LayoutUri { get; set; }

		[JsonProperty(PropertyName = "bg_image")]
		public BackgroundImage BackgroundImage { get; set; }

		//Fun properties
		[JsonProperty(PropertyName = "fun_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public FunType FunType { get; set; }

		//Topic properties
		[JsonProperty(PropertyName = "document_urls")]
		public List<string> DocumentUris { get; set; }

		public List<Document> Documents { get; set; }
		public string Description { get; set; }
	}
}
