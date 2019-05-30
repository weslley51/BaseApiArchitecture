using BaseApiArchitecture.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Interfaces
{
	public interface IController<T> where T : BaseEntity
    {
		Task<Result<BaseEntity>> Get(int Id);
		Task<Result<IEnumerable<BaseEntity>>> Get();
		Task<Result<IEnumerable<BaseEntity>>> Get(int Page = 1, int Quantity = 10);
		Task<Result<IEnumerable<BaseEntity>>> Delete(params T[] Entities);
		Task<IEnumerable<Result<BaseEntity>>> Post(params T[] Entities);
		Task<IEnumerable<Result<BaseEntity>>> Put(params T[] Entities);
	}
}
