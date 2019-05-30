using Newtonsoft.Json;

namespace BaseApiArchitecture.Utils
{
	public static class ObjectExtensions
	{
		public static string Serialize(this object Object)
		{
			return JsonConvert.SerializeObject(Object, new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				PreserveReferencesHandling = PreserveReferencesHandling.None
			});
		}

		public static bool IsAllNull(this object Object)
		{
			return true;
		}
	}
}
