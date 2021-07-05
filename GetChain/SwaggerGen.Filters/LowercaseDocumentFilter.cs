using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GetChain.SwaggerGen.Filters {
    public class LowercaseDocumentFilter : IDocumentFilter {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context) {
            var paths = swaggerDoc.Paths;

            //	generate the new keys
            var newPaths = new Dictionary<string, OpenApiPathItem>();
            var removeKeys = new List<string>();
            foreach ( var (key, value) in paths ) {
                var newKey = key.ToLower();
                if ( newKey != key ) {
                    removeKeys.Add(key);
                    newPaths.Add(newKey, value);
                }
            }

            //	add the new keys
            foreach ( var (key, value) in newPaths ) {
                swaggerDoc.Paths.Add(key, value);
            }

            //	remove the old keys
            foreach ( var key in removeKeys ) {
                swaggerDoc.Paths.Remove(key);
            }
        }
    }
}