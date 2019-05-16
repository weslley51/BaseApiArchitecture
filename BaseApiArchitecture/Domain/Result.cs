using System.Collections.Generic;
using System.Linq;

namespace BaseApiArchitecture.Domain
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public List<string> Messages { get; private set; }
		        
        public Result(T Data, bool IsSuccess, params string[] Messages)
        {
            this.Data = Data;
            this.Messages = Messages?.ToList();
            this.IsSuccess = IsSuccess;
        }

        public Result(bool IsSuccess, params string[] Messages)
        {
            this.IsSuccess = IsSuccess;
            this.Messages = Messages?.ToList();
        }

		public void AddMessage(params string[] Messages)
		{
			if (this.Messages == null)
				this.Messages = new List<string>();

			this.Messages.AddRange(Messages);
		}

		public Result<U> ConvertData<U>(U Data)
		{
			return new Result<U>(Data, IsSuccess, Messages.ToArray());
		}
    }
}
