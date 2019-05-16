using BaseApiArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Interfaces
{
	public interface IRepository<T> : IDisposable where T : BaseEntity
    {
		Task<T> GetById(int Id);
		Task<IEnumerable<T>> GetWithFilter(IFilter<T> BaseFilter);
		Task<IEnumerable<T>> GetWithFilter(Expression<Func<T, bool>> Predicate, bool Readonly = true, int? Page = 1, int? Quantity = 10, params Expression<Func<T, object>>[] Includes);
		Task<IEnumerable<T>> Delete(params int[] Ids);
		Task<IEnumerable<T>> Insert(params T[] Entities);
		Task<IEnumerable<T>> Update(params T[] Entities);
	}
}
