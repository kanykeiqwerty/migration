using System.ComponentModel.DataAnnotations;

namespace MigrationApi.Models
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty; 
    }
}