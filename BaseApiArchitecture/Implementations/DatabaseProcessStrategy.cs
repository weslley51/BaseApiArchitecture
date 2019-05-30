using BaseApiArchitecture.Interfaces;
using BaseApiArchitecture.Domain;
using System;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Implementations
{
    public class DatabaseProcessStrategy : IProcessStrategy
    {
		private int UserId { get; set; }
		private IUnitOfWork UnitOfWork { get; set; }
        private ILogService LogService { get; set; }

		public DatabaseProcessStrategy(IUnitOfWork UnitOfWork, ILogService LogService)
		{
			this.LogService = LogService;
			this.UnitOfWork = UnitOfWork;

		}

		public async Task<Result<T>> Process<T> (Func<Task<T>> Function)
        {
			try
			{
				var Result = await Function();
				await UnitOfWork.Commit();
				return new Result<T>(Result, true);
			}
			catch (ValidationException ex)
			{
				if (ex.Entity is T)
					return new Result<T>((T)ex.Entity, false, ex.Errors.ToArray());
				else
					return new Result<T>(false, ex.Errors.ToArray());
			}
			catch (Exception ex)
			{
				var Message = await LogService.SaveExceptions(ex);
				return new Result<T>(false, new string[] { Message });
			}
			finally
			{
				UnitOfWork.Close();
			}
		}
	}
}
