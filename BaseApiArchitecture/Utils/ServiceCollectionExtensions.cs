using BaseApiArchitecture.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace BaseApiArchitecture.Utils
{
	public static class ServiceCollectionExtensions
	{
		public static void RegisterAllConcreteTypes(this IServiceCollection Services, Type Type, Assembly[] Assemblies, ServiceLifetime ServiceLifetime = ServiceLifetime.Scoped)
		{
			var Implementations = Assemblies.SelectMany(a => a.DefinedTypes.Where(t => !(t.IsInterface || t.IsAbstract) && t.GetInterfaces().Any(f => f.Name == Type.Name && f.GenericTypeArguments.Any(g => g.IsSubclassOf(typeof(BaseEntity))))));

			foreach (var Implementation in Implementations)
			{
				var InterfaceType = Implementation.ImplementedInterfaces.FirstOrDefault(x => x.FullName.Contains(Type.FullName));
				Services.Add(new ServiceDescriptor(InterfaceType, Implementation, ServiceLifetime));
			}
		}

		public static void RegisterAllGenericTypes(this IServiceCollection Services, Type InterfaceType, Type GenericType, Assembly[] Assemblies, ServiceLifetime ServiceLifetime = ServiceLifetime.Scoped)
		{
			var Classes = Assemblies.SelectMany(a => a.DefinedTypes.Where(t => !(t.IsAbstract) && t.IsSubclassOf(typeof(BaseEntity))));
			var Implementeds = Services.Where(x => x.ServiceType.Name == InterfaceType.Name).SelectMany(x => x.ServiceType.GenericTypeArguments);
			Classes = Classes.Where(x => !Implementeds.Any(i => i == x.AsType()));

			foreach (var Type in Classes)
				Services.Add(new ServiceDescriptor(InterfaceType.MakeGenericType(new[] { Type }), GenericType.MakeGenericType(new[] { Type }), ServiceLifetime));
		}
	}
}
