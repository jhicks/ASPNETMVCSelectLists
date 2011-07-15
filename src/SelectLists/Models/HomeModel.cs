using SelectLists.Support;

namespace SelectLists.Models
{
    public class HomeModel
    {
        [SelectListProvidedBy(typeof(EnumSelectListProvider<BuildingType>))]
        public BuildingType BuildingType { get; set; }

        [SelectListProvidedBy(typeof(EnumSelectListProvider<BuildingType>))]
        public BuildingType[] ArrayOfBuildingTypes { get; set; }

        [SelectListProvidedBy(typeof(HomeSelectListProvider))]
        public long HomeId { get; set; }

        [SelectListProvidedBy(typeof(HomeSelectListProvider))]
        public long? HomeIdNullable { get; set; }

        [SelectListProvidedBy(typeof(HomeSelectListProvider))]
        public string HomeIdAsString { get; set; }
    }
}