namespace MigrationApi.Dto
{
    public class CitizenFormDto
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PIN { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }

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
        public DateOnly BirthDate { get; set; }
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





    }


    public class CreateCitizenFormDto
    {
        public DateTime RegistrationDate { get; set; }

        public string PIN { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
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



        public int MaritalStatusId { get; set; }






    }
    public class UpdateCitizenFormDto
    {
     
        public DateOnly BirthDate { get; set; }
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
        


        


   }
}