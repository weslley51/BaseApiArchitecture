using BaseApiArchitecture.Domain;
using BaseApiArchitecture.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApiArchitecture.Utils
{
	public static class BaseOperationsExtensions
	{
		public static async Task<string> Validate<T, U>(this IBaseOperations<T> Validator, T Entity, U PropertyEntity, IRepository<U> Repository)
			where T : BaseEntity
			where U : BaseEntity
		{
			var Erro = string.Empty;
			var Propriedades = Entity.GetType().GetProperties().Where(x => x.ReflectedType == typeof(U));

			foreach (var Propriedade in Propriedades)
			{
				if ((Propriedade.GetValue(Entity) as U).Id == PropertyEntity.Id)
				{
					var Resultado = await CheckInDatabase(Propriedade.GetValue(Entity) as U, Repository);

					if (Resultado.IsSuccess)
						Propriedade.SetValue(Entity, Resultado.Data);
					else
						Erro = $"{typeof(U).Name} - {Resultado?.Messages?.FirstOrDefault()}";

					break;
				}
			}

			return Erro;
		}

		private static async Task<Result<T>> CheckInDatabase<T>(T Entity, IRepository<T> Repository) where T : BaseEntity
		{
			if (Entity.Id <= 0)
				return new Result<T>(Entity, false, "deve ser preenchido!");
			else
			{
				var DatabaseEntity = await Repository.GetById(Entity.Id);

				if (DatabaseEntity == null)
					return new Result<T>(Entity, false, "não foi encontrado!");

				return new Result<T>(DatabaseEntity, true);
			}
		}
	}
}
