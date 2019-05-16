using BaseApiArchitecture.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Interfaces
{
	public interface IBaseOperations<T> where T : BaseEntity
    {
		Task<Result<T>> GetById(int Id);
		Task<Result<IEnumerable<T>>> GetAll(int Page = 1, int Quantity = 10);
		Task<Result<IEnumerable<T>>> GetWithFilter(IFilter<T> Filter);
		Task<Result<IEnumerable<T>>> Delete(bool Commit = true, params int[] Ids);
		//Task<IEnumerable<Result<T>>> Save(bool Commit = true, params T[] Entities);
	}
}
