using BaseApiArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Interfaces
{
	public interface IRepository<T> : IDisposable where T : BaseEntity
    {
		Task<T> GetById(T Entity);
		Task<IEnumerable<T>> GetWithFilter(IFilter<T> BaseFilter);
		//Task<IEnumerable<T>> GetWithFilter(Expression<Func<T, bool>> Predicate, bool Readonly = true, int? Page = 1, int? Quantity = 10, params Expression<Func<T, object>>[] Includes);
		Task Delete(params T[] Entities);
		Task Insert(params T[] Entities);
		Task Update(params T[] Entities);
	}
}
