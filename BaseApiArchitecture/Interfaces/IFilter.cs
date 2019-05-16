using BaseApiArchitecture.Domain;
using System.Collections.Specialized;

namespace BaseApiArchitecture.Interfaces
{
	public interface IFilter<T> where T : BaseEntity
    {
		void Initialize(NameValueCollection Parameters);
    }
}
