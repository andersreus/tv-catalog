using TvCatalog.Web.Models.ServiceModels;

namespace TvCatalog.Web.Services
{
    public interface IImportContentService
    {
        Task<IEnumerable<TVmazeModel>> ImportContentAsync(int parentKey);
    }
}
