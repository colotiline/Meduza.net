using System;

namespace Meduza.net.Exceptions {
	public sealed class EmptyAnswerException : Exception {
		public EmptyAnswerException(string message) : base(message) {
		}
	}
}
