namespace MigrationApi.Dto
{
    public class RegionDto
    {
        
        public string Name { get; set; } = string.Empty;
        public ICollection<DistrictDto> District { get; set; } = new List<DistrictDto>();

    }

    public class CreateRegionDto
    {
        public int RegionId { get; set; }
        public string Name { get; set; } = string.Empty;


    }
}