using BaseApiArchitecture.Domain;
using System;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Interfaces
{
	public interface ILogService
    {
		Task<string> SaveExceptions(Exception Exception, int UserId);
		Task SaveChanges(BaseEntity OldObject, BaseEntity NewObject, int UserId);
	}
}

