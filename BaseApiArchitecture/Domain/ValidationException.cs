using System;
using System.Collections.Generic;

namespace BaseApiArchitecture.Domain
{
    public class ValidationException : Exception
    {
		public object Entity { get; set; }
        public List<string> Errors { get; set; }

        public ValidationException(object Entity, params string[] Errors)
        {
			this.Entity = Entity;
            this.Errors = new List<string>(Errors);
        }
    }
}
