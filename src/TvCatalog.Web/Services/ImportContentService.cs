using TvCatalog.Web.Models.ServiceModels;
using Umbraco.Cms.Core.Services;

namespace TvCatalog.Web.Services
{
    public class ImportContentService : IImportContentService
    {
        private readonly IContentService _contentService;
        private readonly ITVmazeService _tvmazeService;

        public ImportContentService(IContentService contentService, ITVmazeService tVmazeService)
        {
            _contentService = contentService;
            _tvmazeService = tVmazeService;

        }
        public async Task<IEnumerable<TVmazeModel>> ImportContentAsync(int parentKey)
        {
            var allShows = await _tvmazeService.GetAllAsync();

            foreach (var show in allShows)
            {
                // TODO: Use publishedcontent instead, it's more efficient.
                // contentservice goes to the database, publishedcontent will use the cache.

                // TODO: Check if content is already imported.
                // GetAll children by parent id, if contains(show.Name) break, else Continue
                var tvshow = _contentService.Create($"{show.Name}", parentKey, "tVShow");

                // Doesn't make sense to set the name? Set the other values.
                // tvshow.SetValue("showName", $"{show.Name}");

                _contentService.SaveAndPublish(tvshow);
            }

            return allShows;
        }
    }
}
