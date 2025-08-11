using System.ComponentModel.DataAnnotations;

namespace MigrationApi.Models
{
    public class District
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;
        public int RegionId { get; set; }
        public Region? Region { get; set; }
        
    }
}