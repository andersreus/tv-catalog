using TvCatalog.Web.Services;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.PublishedCache;

public class ImportTvShowsAsContent : INotificationHandler<ContentSavedNotification>
{
    private readonly IImportContentService _importContentService;
    private readonly IPublishedSnapshotAccessor _publishedSnapshotAccessor;

    public ImportTvShowsAsContent(IImportContentService importContentService, IPublishedSnapshotAccessor publishedSnapshotAccessor)
    {
        _importContentService = importContentService;
        _publishedSnapshotAccessor = publishedSnapshotAccessor;
    }
    public void Handle(ContentSavedNotification notification)
    {
        _publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot);
        var publishedContentCache = publishedSnapshot.Content;
        var rootContent = publishedContentCache.HasContent();
        if (rootContent is false)
            // Der er content, den skal check for under root content node
            _importContentService.ImportContentAsync(-1);
    }
}