using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using WadDB.Wads.Models;

namespace WadDB.Wads.Drivers {
    public class WadPartDriver : ContentPartDriver<WadPart> {

        protected override string Prefix => "Wad";

        protected override DriverResult Display(WadPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Wad",
                () => shapeHelper.Parts_Wad(WadPart: part));
        }

        //GET
        protected override DriverResult Editor(WadPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Wad_Edit", () =>
                shapeHelper.EditorTemplate(TemplateName: "Parts/Wad", Model: part, Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(WadPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}