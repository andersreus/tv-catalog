using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvCatalog.Web.Models.ServiceModels;

namespace TvCatalog.Web.Services
{
    public interface ITVmazeService
    {
        // Simplified naming. Nothing about the implementation
        IEnumerable<TVmazeModel> GetAll();
    }
}
