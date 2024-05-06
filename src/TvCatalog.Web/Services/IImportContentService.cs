using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvCatalog.Web.Models.ServiceModels;

namespace TvCatalog.Web.Services
{
    public interface IImportContentService
    {
        Task<IEnumerable<TVmazeModel>> ImportContentAsync(int parentKey);
    }
}
