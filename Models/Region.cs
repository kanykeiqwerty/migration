using System.ComponentModel.DataAnnotations;

namespace MigrationApi.Models
{
    public class Region
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;

        public ICollection<District> District { get; set; } = new List<District>();
    }
}