using GraphQLAPI.Data;
using GraphQLAPI.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.GraphQL.Types
{
	public class PlatformType : ObjectType<Platform>
	{
		protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
		{
			descriptor.Description("Representar cualquier software o servicio que tenga una interfaz de línea de comandos");
			
			descriptor
				.Field(p => p.LicenseKey).Ignore();

			descriptor
				.Field(p => p.Commands)
				// Se utiliza para filtrar
				//.UseFiltering()
				// se utiliza para ordenar
				//.UseSorting()
				//.UsePaging()
				.ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
				.UseDbContext<AppDbContext>()
				.Description("Esta es la lista de comandos disponibles para esta plataforma.");
		}

		private class Resolvers
		{
			public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
			{
				return context.Commands.Where(p => p.PlatformId == platform.Id);
			}
		}
	}
}