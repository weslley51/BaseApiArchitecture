using System.Collections.Specialized;
using BaseApiArchitecture.Interfaces;
using BaseApiArchitecture.Utils;

namespace BaseApiArchitecture.Domain
{
	public class BaseFilter<T> : IFilter<T> where T : BaseEntity
	{
		public int? Page { get; set; }
		public int? Quantity { get; set; }

		public virtual void Initialize(NameValueCollection Parameters)
		{
			Page = Parameters.GetParameter<int>("Page");
			Quantity = Parameters.GetParameter<int>("Quantity");
		}
	}
}
