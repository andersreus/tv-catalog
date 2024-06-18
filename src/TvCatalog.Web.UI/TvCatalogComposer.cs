using TvCatalog.Web.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Notifications;

namespace TvCatalog.Web.UI
{
    public class TvCatalogComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<ContentSavedNotification, ImportTvShowsAsContent>();
            builder.Services.AddTransient<IImportContentService, ImportContentService>();
            builder.Services.AddTransient<ITVmazeService, TVmazeService>();
        }
    }
}
