using BaseApiArchitecture.Interfaces;
using BaseApiArchitecture.Domain;
using System;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Implementations
{
    public class FunctionProcessStrategy : IProcessStrategy
    {
        private int UserId { get; set; }
        private ILogService LogService { get; set; }

		public FunctionProcessStrategy(ILogService LogService)
		{
			this.LogService = LogService;
		}

		public async Task<Result<T>> Process<T> (Func<Task<T>> Function)
        {
            try
            {
                var Result = await Function();
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
				var Message = await LogService.SaveExceptions(ex, UserId);
				return new Result<T>(false, new string[] { Message });
			}        
        }
    }
}
