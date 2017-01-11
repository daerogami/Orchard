using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace WadDB.Wads
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            ContentDefinitionManager.AlterTypeDefinition("Wad", builder => builder
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("AutoroutePart", partBuilder =>
                    partBuilder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Wad Title', Pattern: 'wads/{Content.Slug}', Description: 'wads/wad-title'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .WithPart("BodyPart", partBuilder => 
                    partBuilder.WithSetting("BodyTypePartSettings.Flavor", "text"))
                    .WithPart("WadPart")
                .Creatable()
                .Draftable());

            SchemaBuilder.CreateTable("WadPartRecord", table =>
                    table.ContentPartRecord()
                    .Column<string>("Authors"));

            return 1;
        }
    }
}