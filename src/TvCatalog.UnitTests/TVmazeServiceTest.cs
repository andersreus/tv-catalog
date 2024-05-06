using Microsoft.Extensions.DependencyInjection;
using TvCatalog.Web.Services;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Tests.Common.Builders;
using Umbraco.Cms.Tests.Common.Builders.Extensions;
using Umbraco.Cms.Tests.Common.Testing;
using Umbraco.Cms.Tests.Integration.Testing;


namespace TvCatalog.UnitTests
{
    [TestFixture]
    [UmbracoTest(Database = UmbracoTestOptions.Database.NewSchemaPerTest)]
    public class TVmazeServiceTest : UmbracoIntegrationTest
    {
        private ITVmazeService _tvmazeService;
        private IImportContentService _importContentService;
        private IContentService _contentService;

        [SetUp]
        public void Setup()
        {
            var contentService = GetRequiredService<IContentService>();
            _tvmazeService = new TVmazeService(contentService);
            _importContentService = new ImportContentService(contentService, _tvmazeService);
        }

        // This service should automacitally be added using the Umbraco.Cms.Tests.Integration nuget package. Bug?
        protected override void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureTestServices(services);
            services.AddSingleton<IApiContentPathProvider, ApiContentPathProvider>();
        }

        [Test]
        public async Task Test1()
        {
            var allModels = await _tvmazeService.GetAllAsync();
            Assert.IsTrue(allModels.Any());
        }

        [Test]
        public async Task Test()
        {
            // Always test on a fresh/test database. You don't want to test on your actual live database.
            // TODO: Simulate the exact backoffice setup in my test.

            // Create a ContentType (Document type) and save it
            var contentType = new ContentTypeBuilder()
                .WithId(0)
                .WithAlias("tVShow")
                .Build();
            contentType.AllowedAsRoot = true;

            var contentTypeSerivce = GetRequiredService<IContentTypeService>();
            contentTypeSerivce.Save(contentType);

            // Call importcontent, pass in the unique identifier for the contenttype (parentId used in the create method)
            // Right now parentKey is hardcorded to -1 to insert all content as rootnodes.
            var importedContent = await _importContentService.ImportContentAsync(-1);
            var contentService = GetRequiredService<IContentService>();

            int count = contentService.Count("tVShow");
            Assert.IsTrue(count > 0);           
            
        }
    }
}