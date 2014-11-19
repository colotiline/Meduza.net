using System;
using System.Collections.Generic;
using Meduza.net.Helpers;
using Meduza.net.Models.Api.Card;
using Meduza.net.Models.Api.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meduza.net.Models.Api {
	public class Document {
		private readonly string _uri;
		private readonly string _title;
		private readonly string _secondTitle;
		private readonly IReadOnlyList<IReadOnlyList<string>> _authors;
		private readonly DocumentType _documentType;
		private readonly int _version;
		private readonly DateTime _publishedAt;
		private readonly DateTime _updatedAt;
		private readonly bool _isFull;
		private readonly Source _source;
		private readonly Image _image;
		public Document(
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
			Image image) {
			_uri = uri;
			_title = title;
			_secondTitle = secondTitle;
			_authors = authors;
			_documentType = documentType;
			_version = version;
			_publishedAt = publishedAt;
			_updatedAt = updatedAt;
			_isFull = isFull;
			_source = source;
			_image = image;
		}
		public string Uri {
			get { return _uri; }
		}
		public string Title {
			get { return _title; }
		}
		public string SecondTitle {
			get { return _secondTitle; }
		}
		public IReadOnlyList<IReadOnlyList<string>> Authors {
			get { return _authors; }
		}
		public DocumentType DocumentType {
			get { return _documentType; }
		}
		public int Version {
			get { return _version; }
		}
		public DateTime PublishedAt {
			get { return _publishedAt; }
		}
		public DateTime UpdatedAt {
			get { return _updatedAt; }
		}
		public bool IsFull {
			get { return _isFull; }
		}
		public Source Source {
			get { return _source; }
		}
		public Image Image {
			get { return _image; }
		}
		
		//Card properties
		[JsonProperty(PropertyName = "chapters_count")]
		public int ChaptersQuantity { get; set; }

		[JsonProperty(PropertyName = "table_of_contents")]
		public IReadOnlyList<string> TableOfContents { get; set; }

		public string Thesis { get; set; }

		public IReadOnlyList<Chapter> Chapters { get; set; }

		[JsonProperty(PropertyName = "layout_url")]
		public string LayoutUri { get; set; }

		[JsonProperty(PropertyName = "bg_image")]
		public BackgroundImage BackgroundImage { get; set; }

		//Fun properties
		[JsonProperty(PropertyName = "fun_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public FunType FunType { get; set; }

		//Topic properties
		public IReadOnlyList<string> Content { get; set; }
		public IReadOnlyList<Document> Documents { get; set; } 
	}
}
