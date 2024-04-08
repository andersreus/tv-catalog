using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TvCatalog.Web.Models.ServiceModels;

namespace TvCatalog.Web.Services
{
    public class TVmazeService : ITVmazeService
    {
        public IEnumerable<TVmazeModel> GetAll()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.tvmaze.com/shows?page=0");

            // Can't use ClientFactory, like the blazor project. Find out why?
            var client = new HttpClient();

            var response = client.Send(request);

            var jsonString = response.Content.ReadAsStream();

            var allShows = JsonSerializer.Deserialize<List<TVmazeModel>>(jsonString);

            return allShows;
        }
    }
}
