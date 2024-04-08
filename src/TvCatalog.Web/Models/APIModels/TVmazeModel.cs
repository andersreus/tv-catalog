using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TvCatalog.Web.Models.ServiceModels
{
    public class TVmazeModel
    {
        // GET - https://api.tvmaze.com/shows?page=0
        // TODO: Add properties based on postman call. Image, genre etc

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
