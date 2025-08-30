using System.Diagnostics.Eventing.Reader;

namespace MigrationApi.Dto
{
    public class CitizenFormDto
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PIN { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
        // public RegionDto? Region { get; set; } 

        public DistrictDto? District { get; set; }


        public List<MigrationDto> Migrations { get; set; } = new List<MigrationDto>();

    }

    public class OneCitizenFormDto
    {
        public DateTime RegistrationDate { get; set; }
        public Guid Id { get; set; }
        public string PIN { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MidName { get; set; }
        public string? Disabilities { get; set; }
        public string? PhoneNumber { get; set; }
        public int? ESYBMId { get; set; }
        public string? ENIcode { get; set; }
        public string? RuralArea { get; set; }
        public string? PopulationArea { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Apartments { get; set; }
        public DistrictDto? District { get; set; }
        public StatusDto? Status { get; set; }

        public MaritalStatusDto? MaritalStatus { get; set; }
        public List<MigrationHistoryDto> Migrations { get; set; } = new List<MigrationHistoryDto>();

        public string? CreatedByUserName { get; set; }
        public string? UpdatedByUserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsArchived { get; set; } = false;





    }


    public class CreateCitizenFormDto
    {
        public DateTime RegistrationDate { get; set; }

        public string PIN { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MidName { get; set; }
        public string? Disabilities { get; set; }
        public string? PhoneNumber { get; set; }
        public int? ESYBMId { get; set; }
        public string? ENIcode { get; set; }
        public string? RuralArea { get; set; }
        public string? PopulationArea { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Apartments { get; set; }
        public int DistrictId { get; set; }
        public int StatusId { get; set; }
        // public string? CreatedByUserName { get; set; }
        // public DateTime CreatedAt { get; set; }



        public int MaritalStatusId { get; set; }






    }
    public class UpdateCitizenFormDto
    {

        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MidName { get; set; }
        public string? Disabilities { get; set; }
        public string? PhoneNumber { get; set; }

        public string? RuralArea { get; set; }
        public string? PopulationArea { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Apartments { get; set; }
        public int DistrictId { get; set; }
        public int StatusId { get; set; }



        public int MaritalStatusId { get; set; }
        public bool IsArchived { get; set; } = false;





    }

    public class CitizenFormFilterDto
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        // public int totalCount { get; set; }
        public DateTime? RegistrationDateFrom { get; set; }
        public DateTime? RegistrationDateTo { get; set; }
        
         public int? BirthYear { get; set; }
        public string? Pin { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string? Region { get; set; }
        public string? District { get; set; }
        public string? MigrationCountry { get; set; }
        public DateTime? DepartureDate { get; set; }
    public bool? IsArchived { get; set; }
   }
}