using System.Collections.Generic;
using System.Threading.Tasks;
using BaseApiArchitecture.Interfaces;
using BaseApiArchitecture.Domain;
using BaseApiArchitecture.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
using System.Linq;

namespace BaseApiArchitecture.Implementations
{
	[Route("api/[controller]")]
	public class Controller<T> : Controller/*, IController<T>*/ where T : BaseEntity
	{
		protected IFilter<T> Filters { get; set; }
		protected IBaseOperations<T> Service { get; set; }

		public Controller(IBaseOperations<T> Service, IFilter<T> Filters)
		{
			this.Filters = Filters;
			this.Service = Service;
		}

		// GET api/values
		[HttpGet]
		public virtual async Task<Result<IEnumerable<BaseEntity>>> Get()
		{
			Result<IEnumerable<T>> Result;
			Filters.Initialize(HttpUtility.ParseQueryString(Request.QueryString.Value));

			if (Filters.IsAllNull())
				Result = await Service.GetAll(1, 10);
			else
				Result = await Service.GetWithFilter(Filters);

			return Result.ConvertData(Result.Data.Cast<BaseEntity>());
		}

		// GET api/values/1/10
		[HttpGet("{Page}/{Quantity}")]
		public virtual async Task<Result<IEnumerable<BaseEntity>>> Get(int Page = 1, int Quantity = 10)
		{
			var Result = await Service.GetAll(Page, Quantity);
			return Result.ConvertData(Result.Data.Cast<BaseEntity>());
		}

		// GET api/values/5
		[HttpGet("{Id}")]
		public virtual async Task<Result<BaseEntity>> Get(int Id)
		{
			var Result = await Service.GetById(Id);
			return Result.ConvertData(Result.Data as BaseEntity);
		}
		
		// POST api/values
		//[HttpPost]
		//public virtual async Task<IEnumerable<Result<BaseEntity>>> Post([FromBody]params T[] Entities)
		//{
		//	return ConvertResult(await Service.Save(true, Entities));
		//}
		//
		//// PUT api/values/
		//[HttpPut]
		//public virtual async Task<IEnumerable<Result<BaseEntity>>> Put([FromBody]params T[] Entities)
		//{
		//	return ConvertResult(await Service.Save(true, Entities));
		//}
		//
		//// DELETE api/values/5
		//[HttpDelete]
		//public virtual async Task<Result<IEnumerable<BaseEntity>>> Delete([FromBody]params int[] Ids)
		//{
		//	var Result = await Service.Delete(true, Ids);
		//	return Result.ConvertData(Result.Data.Cast<BaseEntity>());
		//}
		//
		//protected IEnumerable<Result<BaseEntity>> ConvertResult(IEnumerable<Result<T>> Result)
		//{
		//	var Converted = new List<Result<BaseEntity>>();
		//	Result.ToList().ForEach(x => Converted.Add(x.ConvertData(x.Data as BaseEntity)));
		//	return Converted;
		//}
	}
}
