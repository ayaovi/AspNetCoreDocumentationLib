using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

public class DefinitionsDocumentFilter : IDocumentFilter
{
  public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
  {
    swaggerDoc.Definitions.ToList().ForEach(x => {
      x.Value.Extensions.Add("$id", $"#/definitions/{x.Key}");
    });
  }
}