﻿using System.Runtime.Serialization;

namespace Meduza.net.Models.Api.Enum {
	public enum DocumentType {
        Promo,
		Feature,
		News,
		Card,
		Fun,
		Topic,
		Gallery,
		[EnumMember(Value = "new_year_card")] NewYearCard,
        Rotation,
        Live
	}
}
