using GraphQLAPI.Data;
using GraphQLAPI.GraphQL.Types;
using GraphQLAPI.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLAPI.GraphQL
{
	public class Query
	{
		// Db Context multiple proceso
		[UseDbContext(typeof(AppDbContext))]
		// se usan las Proyecciones para que la busqueda tambien traiga datos de sus llaves foraneas
		[UseProjection]
		// Se utiliza para filtrar
		[UseFiltering]
		// se utiliza para ordenar
		[UseSorting]
		public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context) //[ScopedService] se utiliza para habilitar consultas por multiples proceso
		{
			return context.Platforms;
		}

		// Db Context multiple proceso
		[UseDbContext(typeof(AppDbContext))]
		// se usan las Proyecciones para que la busqueda tambien traiga datos de sus llaves foraneas
		[UseProjection]
		// Se utiliza para filtrar
		[UseFiltering]
		// se utiliza para ordenar
		[UseSorting]
		public IQueryable<Command> GetCommand([ScopedService] AppDbContext context) //[ScopedService] se utiliza para habilitar consultas por multiples proceso
		{
			return context.Commands;
		}

		// Db Context multiple proceso
		[UseDbContext(typeof(AppDbContext))]
		// se usan las Proyecciones para que la busqueda tambien traiga datos de sus llaves foraneas
		[UseProjection]
		// Se utiliza para filtrar
		[UseFiltering]
		// se utiliza para ordenar
		[UseSorting]
		// se utiliza para paginar
		[UsePaging(typeof(PlatformType))]
		public IQueryable<Platform> GetPlatformPagination([ScopedService] AppDbContext context) //[ScopedService] se utiliza para habilitar consultas por multiples proceso
		{
			return context.Platforms;
		}


		// Db Context multiple proceso
		[UseDbContext(typeof(AppDbContext))]
		// se usan las Proyecciones para que la busqueda tambien traiga datos de sus llaves foraneas
		[UseProjection]
		// Se utiliza para filtrar
		[UseFiltering]
		// se utiliza para ordenar
		[UseSorting]
		// se utiliza para paginar
		[UsePaging]
		public IQueryable<Command> GetCommandPagination([ScopedService] AppDbContext context) //[ScopedService] se utiliza para habilitar consultas por multiples proceso
		{
			return context.Commands;
		}

		// Db Context normal
		//public IQueryable<Platform> GetPlatforms([Service] AppDbContext context)
		//{
		//	return context.Platforms;
		//}
	}
}