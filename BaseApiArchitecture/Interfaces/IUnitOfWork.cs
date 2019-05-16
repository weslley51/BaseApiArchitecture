using System;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Interfaces
{
    public interface IUnitOfWork : IDisposable
	{
        Task Commit();
        void Close();
        string GetContextId();
    }
}