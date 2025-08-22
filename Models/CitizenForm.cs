using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace MigrationApi.Models
{
    public class CitizenForm
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string PIN { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? MidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly BirthDate { get; set; }

        public Gender Gender { get; set; }


        public string? Disabilities { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        public int? ESYBMId { get; set; }
        public string? ENIcode { get; set; }
        public string? RuralArea { get; set; }
        public string? PopulationArea { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Apartments { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }
        public int MaritalStatusID { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }

        
        public int DistrictID { get; set; }
        public District? District { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created_at { get; set; }

        // public Guid CreatedByUserID { get; set; }

        // public Guid UpdatedByUserID { get; set; }
        // [ForeignKey(nameof(CreatedByUserID))]
        // public User? CreatedByUser { get; set; }
        // [ForeignKey(nameof(UpdatedByUserID))]
        // public User? UpdatedByUser { get; set; }

        public bool IsArchived { get; set; } = false;

         public int? StatusID { get; set; }
         public Status? Status { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(MidName))
                {
                    return $"{LastName} {FirstName} {MidName}";
                }

                return $"{LastName} {FirstName}";
            }
        }
    
    public ICollection<Migration> Migrations { get; set; } = [];
}

    }


public enum Gender : byte
{
    Male = 0,
    Female = 1
}