using BaseApiArchitecture.Domain;
using System;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Interfaces
{
    public interface IProcessStrategy
    {
        Task<Result<T>> Process<T>(Func<Task<T>> Function);
    }
}
