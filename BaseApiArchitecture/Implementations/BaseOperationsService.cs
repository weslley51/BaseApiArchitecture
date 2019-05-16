using System.Collections.Generic;
using System.Threading.Tasks;
using BaseApiArchitecture.Interfaces;
using BaseApiArchitecture.Domain;
using System.Linq;
using System;

namespace BaseApiArchitecture.Implementations
{
	public class BaseOperationsService<T> : IBaseOperations<T> where T : BaseEntity
	{
		protected IRepository<T> Repository { get; private set; }
		protected IProcessStrategy FunctionProcessStrategy { get; private set; }
		protected IProcessStrategy DatabaseProcessStrategy { get; private set; }

		public BaseOperationsService(IRepository<T> Repository, IProcessStrategy ProcessStrategy, IUnitOfWork UnitOfWork, ILogService LogService)
		{
			this.Repository = Repository;
			FunctionProcessStrategy = ProcessStrategy;
			DatabaseProcessStrategy = new DatabaseProcessStrategy(UnitOfWork, LogService);
		}

		public virtual async Task<Result<T>> GetById(int Id)
		{
			return await FunctionProcessStrategy.Process(async () => await Repository.GetById(Id));
		}

		public virtual async Task<Result<IEnumerable<T>>> GetAll(int Page = 1, int Quantity = 10)
		{
			return await FunctionProcessStrategy.Process(async () => await Repository.GetWithFilter(x => x.Id != 0));
		}

		public virtual async Task<Result<IEnumerable<T>>> GetWithFilter(IFilter<T> Filter)
		{
			return await FunctionProcessStrategy.Process(async () => await Repository.GetWithFilter(Filter));
		}
		/*
		public virtual async Task<IEnumerable<Result<T>>> Save(bool Commit = true, params T[] Entities)
		{
			Func<Task<IEnumerable<Result<T>>>> Function = async () =>
			{
				var Results = new List<Result<T>>();

				if (ValidatorCommand == null)
					throw new ValidationException(Entities, "Não existe uma classe de validação definida para o objeto !");

				foreach (var Entity in Entities)
					Results.Add(await ValidatorCommand.Execute(Entity));

				var ValidEntities = Results.Where(x => x.IsSuccess).Select(x => x.Data);
				await Repository.Insert(ValidEntities.Where(x => x.Id == 0)?.ToArray());
				await Repository.Update(ValidEntities.Where(x => x.Id != 0)?.ToArray());

				return Results;
			};

			var Result = (await Execute(async () => await Function(), Commit));

			if (Result.IsSuccess)
				return Result.Data;

			return new List<Result<T>> { new Result<T>(false, Result.Messages?.ToArray()) };
		}
		
		public virtual async Task<Result<IEnumerable<T>>> Delete(bool Commit = true, params int[] Ids)
		{
			return await Execute(async () => await Repository.Delete(Ids), Commit);
		}
		
		private async Task<Result<U>> Execute<U>(Func<Task<U>> Function, bool TransactionControl = false)
		{
			return await (TransactionControl ?
							DatabaseProcessStrategy.Process(async () => await Function()) :
							FunctionProcessStrategy.Process(async () => await Function()));
		}
		*/
	}
}
