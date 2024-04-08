using TvCatalog.Web.Services;

namespace TvCatalog.UnitTests
{
    public class TVmazeServiceTest
    {
        private ITVmazeService _tvmazeService;
        [SetUp]
        public void Setup()
        {
            _tvmazeService = new TVmazeService();
        }

        [Test]
        public void Test1()
        {
            var allModels = _tvmazeService.GetAll();
            Assert.IsTrue(allModels.Any());
        }
    }
}