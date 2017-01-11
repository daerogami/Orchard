using Orchard.ContentManagement;

namespace WadDB.Wads.Models {
    public class WadPart: ContentPart<WadPartRecord> {
        public string Authors
        {
            get { return Record.Authors; }
            set { Record.Authors = value; }
        }
    }
}