using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using WadDB.Wads.Models;

namespace WadDB.Wads.Handlers
{
    public class WadHandler : ContentHandler
    {
        public WadHandler(IRepository<WadPartRecord> wadPartRepository) {
            Filters.Add(StorageFilter.For(wadPartRepository));
        }
    }
}