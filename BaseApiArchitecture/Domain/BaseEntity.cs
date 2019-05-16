using System.Collections.Generic;

namespace BaseApiArchitecture.Domain
{
	public abstract class BaseEntity
    {
		public int Id { get; set; }

		public abstract IEnumerable<string> IsValid();
	}
}
