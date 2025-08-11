using System.ComponentModel.DataAnnotations;

namespace MigrationApi.Models
{
    public class MigrationStatus
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;
        
    }
}