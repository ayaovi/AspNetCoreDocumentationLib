using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace testwebapi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc()
      .AddJsonOptions(options =>
			{
				options.SerializerSettings.Formatting = Formatting.Indented;
			});
      services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", 
				new Info { 
					Title = "My API", 
					Version = "v1",
					Description = "A sample API to demo Swashbuckle",
					TermsOfService = "Knock yourself out",
					Contact = new Contact
					{
						Name = "Joe Developer",
						Email = "joe.developer@tempuri.org"
					},
					License = new License
					{
						Name = "Apache 2.0",
						Url = "http://www.apache.org/licenses/LICENSE-2.0.html"
					}
				});
				c.DocumentFilter<DefinitionsDocumentFilter>();
			});
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
      app.UseSwagger(c =>
			{
				c.RouteTemplate = "{documentName}/docs/swagger";
			});
    }
  }
}
