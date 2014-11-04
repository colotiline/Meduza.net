using System;
using Newtonsoft.Json;

namespace Meduza.net.Helpers {
	public sealed class UnixDateTimeConverter : JsonConverter {
		DateTime _unixStartDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			var writerValue = ((DateTime) value - _unixStartDateTime).TotalMilliseconds.ToString();
			writer.WriteRawValue(writerValue);
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			var intValue = reader.Value as int?;
			if (intValue.HasValue) {
				return _unixStartDateTime.AddMilliseconds(intValue.Value);
			}

			var longValue = reader.Value as long?;
			if (longValue.HasValue) {
				return _unixStartDateTime.AddMilliseconds(longValue.Value);
			}

			var doubleValue = reader.Value as double?;
			if (doubleValue.HasValue) {
				return _unixStartDateTime.AddMilliseconds(doubleValue.Value);
			}

			var stringValue = reader.Value as string;
			if (!string.IsNullOrWhiteSpace(stringValue)) {
				return _unixStartDateTime.AddMilliseconds(Double.Parse(stringValue));
			}

			throw new ArgumentException();
		}
		public override bool CanConvert(Type objectType) {
			return objectType == typeof (DateTime);
		}
	}
}
