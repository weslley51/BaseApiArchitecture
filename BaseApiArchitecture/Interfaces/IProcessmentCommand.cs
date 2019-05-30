using BaseApiArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Interfaces
{
	public interface IProcessmentCommand
    {
		//Task<Result<T>> GetById(T Entity);
		//Task<Result<IEnumerable<T>>> GetAll(int Page = 1, int Quantity = 10);
		//Task<Result<IEnumerable<T>>> GetWithFilter(IFilter<T> Filter);
		//Task<Result<IEnumerable<T>>> Delete(bool Commit = true, params T[] Entities);
		//Task<IEnumerable<Result<T>>> Save(bool Commit = true, params T[] Entities);
		Task<Result<U>> Execute<U>(Func<Task<U>> Function, bool TransactionControl = false);
	}
}
