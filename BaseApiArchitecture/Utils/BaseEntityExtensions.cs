using BaseApiArchitecture.Domain;

namespace BaseApiArchitecture.Utils
{
	public static class BaseEntityExtensions
	{
		public static string IsValidReference<T, U>(this T Entity, U Reference, bool IsRequired = true) 
			where T : BaseEntity
			where U : BaseEntity
		{
			if (Reference == null)
				return IsRequired ? "deve ser preenchido!" : string.Empty;

			if (Reference.Id <= 0)
				return "não é uma referência válida!";

			return string.Empty;
		}
	}
}
