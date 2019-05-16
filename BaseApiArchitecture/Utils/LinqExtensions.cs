using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace BaseApiArchitecture.Utils
{
	public static class LinqExtensions
	{
		public static bool ContainsNormalized(this IEnumerable<string> Itens, params string[] Search)
		{
			return Itens.Any(x => Search.Any(y => y.EqualsNormalized(x)));
		}

		public static T? GetParameter<T>(this NameValueCollection Collection, string Parameter) where T : struct
		{
			var Value = Collection.AllKeys.Contains(Parameter) ? Collection[Parameter] : string.Empty; 

			if (string.IsNullOrWhiteSpace(Value))
				return default(T?);

			return (T)Convert.ChangeType(Value, typeof(T));
		}
	}
}
