
//------------------------------------------------------------------
//
// Este es un archivo generado automáticamente no realice cambios manuales
//
//------------------------------------------------------------------

using GraphQLAPI.Data;
using GraphQLAPI.GraphQL.Types;
using GraphQLAPI.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLAPI.GraphQL
{
	public class Query2
	{
	
		[UseDbContext(typeof(AppDbContext))]
		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
		{
			return context.Platforms;
		}
	
		[UseDbContext(typeof(AppDbContext))]
		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
		{
			return context.Commands;
		}
			
	}
}