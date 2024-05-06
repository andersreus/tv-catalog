using System.Text.Json;
using TvCatalog.Web.Models.ServiceModels;
using Umbraco.Cms.Core.Services;

namespace TvCatalog.Web.Services
{
    public class TVmazeService : ITVmazeService
    {
        private readonly IContentService _contentService;

        public TVmazeService(IContentService contentService)
        {
            _contentService = contentService;
        }

        // Add error handling? Try catch + exceptions

        public async Task<IEnumerable<TVmazeModel>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.tvmaze.com/shows?page=0");

            // ClientFactory is better performance wise than HttpClient.
            // ClientFactory can handle the lifecycle of the instance itself, disposing the object when the connection is closed.
            var client = HttpClientFactory.Create();

            var response = await client.SendAsync(request);

            // Cannot convert from string to system.io.stream = using stream instead of string then
            var jsonString = await response.Content.ReadAsStreamAsync();

            var allShows = await JsonSerializer.DeserializeAsync<List<TVmazeModel>>(jsonString);
            
            return allShows;
        }
    }
}
