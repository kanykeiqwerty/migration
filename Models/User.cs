using System.ComponentModel.DataAnnotations;
using System.Net.Quic;
using Microsoft.AspNetCore.Identity;

namespace MigrationApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Login { get; set; } = string.Empty;
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
        public int RoleID { get; set; }
        public Role? Role { get; set; }
        [StringLength(50)]
        // public string ActionType { get; set; } = string.Empty;
        [DataType(DataType.DateTime)]
        public DateTime LoginDate { get; set; }



    }
}