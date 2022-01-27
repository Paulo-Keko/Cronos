using Microsoft.OpenApi.Models;

namespace cronos.api
{
    public class ApiKeyScheme : OpenApiSecurityScheme
    {
        public new string Description { get; set; }
        public new string In { get; set; }
        public new string Name { get; set; }
        public new string Type { get; set; }
    }
}