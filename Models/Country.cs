using System.ComponentModel.DataAnnotations;

namespace MigrationApi.Models
{
    public class Country
    {
        public int Id { get; set; }
        [StringLength(80)]
        public string Name { get; set; } = string.Empty;
    }
}