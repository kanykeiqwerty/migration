using MigrationApi.Models;

namespace MigrationApi.Dto
{
    public class DistrictDto
    {
        public string Name { get; set; } = string.Empty;
        public CreateRegionDto? Region { get; set; }
    }


    public class CreateDistrictDto
    {
        // public int DistrictId{ get; set; }
        public string Name { get; set; } = string.Empty;
        public int RegionId { get; set; }
    }
}