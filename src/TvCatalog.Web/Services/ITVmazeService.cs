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
        // Simplified naming, nothing about the implementation.
        // If the method is Async, suffix the method name with "Async"
        Task<IEnumerable<TVmazeModel>> GetAllAsync();
    }
}
