using GraphQL.Server.Ui.Voyager;
using GraphQLAPI.Data;
using GraphQLAPI.GraphQL;
using GraphQLAPI.GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLAPI
{
	public class Startup
	{
		private readonly IConfiguration Configuration;

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			// el db context en la version .net 5 permite consultar multiples procesos
			// graphql hace uso de esta propiedad por ende usaremos este nuevo db context
			//services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
			services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(
				Configuration.GetConnectionString("GraphQLAPI")
				));

			services
				.AddGraphQLServer()
				.AddQueryType<Query>()
				.AddType<PlatformType>()
				// se usan las Proyecciones para que la busqueda tambien traiga datos de sus llaves foraneas
				.AddProjections()
				.AddFiltering()
				.AddSorting();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGraphQL();
			});

			app.UseGraphQLVoyager( 
			//	new VoyagerOptions() { 
			//	GraphQLEndPoint = "/graphql"
			//}, path: "graphql-voyager"
			);
		}
	}
}