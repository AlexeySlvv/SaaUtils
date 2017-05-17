using System;
using System.Globalization;

namespace SaaUtils
{

	/// <summary>
	/// Different parsers
	/// </summary>
	public static class ParserUtil
	{

		// Nullable parsers' idea from "C# in Depth"

		/// <summary>
		/// Last error message
		/// </summary>
		public static string LastError { get; private set; } = default(string);
		
		/// <summary>
		/// Parse String to Int32
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static int? TryParseToInt(string text)
		{
			if (string.IsNullOrEmpty(text))
				return null;

			int ret;
			if (int.TryParse(text, out ret))
				return ret;

			return null;
		}

		/// <summary>
		/// Parse String to Guid
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static Guid? TryParseToGuid(string text)
		{
			if (string.IsNullOrEmpty(text))
				return null;

			Guid ret;
			if (Guid.TryParse(text, out ret))
				return ret;

			return null;
		}

		/// <summary>
		/// Parse String to DateTime
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static DateTime? TryParseToDateTime(string text)
		{
			if (string.IsNullOrEmpty(text))
				return null;

			DateTime ret;
			if (DateTime.TryParse(text, out ret))
				return ret;

			return null;
		}

		/// <summary>
		/// Parse String to Decimal
		/// </summary>
		/// <param name="text"></param>
		/// <returns>InvariantCulture.Decimal or null</returns>
		public static decimal? TryParseToDecimal(string text)
		{
			if (string.IsNullOrEmpty(text))
				return null;

			try
			{
				string curDecSep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
				string invDecSep = NumberFormatInfo.InvariantInfo.NumberDecimalSeparator;

				// Convert to invariant culture
				return Convert.ToDecimal(text.Replace(curDecSep, invDecSep), CultureInfo.InvariantCulture);
			}
			catch (FormatException)
			{
				LastError = $"Error parse to Decimal: uncorrent format {text}";
			}
			catch (OverflowException)
			{
				LastError = $"Error parse to Decimal: {text} out of range";
			}

			return null;
		}

		/// <summary>
		/// Parse String to another type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="text"></param>
		/// <param name="handler">Type.TryParse() method handler</param>
		/// <returns></returns>
		public static T? TryParse<T>(string text, TryParseHandler<T> handler)where T : struct
		{   // http://stackoverflow.com/a/6553694
			if (string.IsNullOrEmpty(text))
				return null;

			T ret;
			if (handler(text, out ret))
				return ret;

			return null;
		}

		/// <summary>
		/// TryParse() method handler
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="text"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public delegate bool TryParseHandler<T>(string text, out T result);

	}
}
