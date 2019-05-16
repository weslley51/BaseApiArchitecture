using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BaseApiArchitecture.Utils
{
	public static class StringExtensions
	{
		public static bool IsNullOrWhiteSpace(this string Value)
		{
			return string.IsNullOrWhiteSpace(Value);
		}

		public static bool EqualsNormalized(this string Main, string String)
		{
			if (Main != null && String != null)
				return string.Compare(Regex.Replace(Main, @"\s", ""), Regex.Replace(String, @"\s", ""), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0;

			return Main == String;
		}

		public static bool ContainsNormalized(this string Main, string String)
		{
			if (Main != null && String != null)
				return Main.ToUpper().Contains(String.ToUpper());

			return Main == String;
		}

		public static bool ContainsAny(this string Main, params string[] Strings)
		{
			foreach (var String in Strings)
				if (Main.IndexOf(String, StringComparison.OrdinalIgnoreCase) >= 0) return true;

			return false;
		}

		public static bool IsGreatenThan(this string Text, int Length)
		{
			return !string.IsNullOrEmpty(Text) && Text.Length > Length;
		}
	}
}
