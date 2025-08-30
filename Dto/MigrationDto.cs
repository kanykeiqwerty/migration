namespace MigrationApi.Dto
{
    public class MigrationDto
    {
        // public Guid CitizenFormID { get; set; }
        public DateTime DepartureDate { get; set; }
        public string? CountryName { get; set; }

    }

    public class MigrationOneDto
    {
        public Guid CitizenFormID { get; set; }


        public int CountryId { get; set; }


        // public MigrationStatusDto? MigrationStatus { get; set; }



        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }
        public string? Profession { get; set; }
        public bool EmploymentContract { get; set; }



    }

    public class MigrationHistoryDto
    {
        public Guid Id { get; set; }
        public string? CountryName { get; set; }
        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }
        public string? Profession { get; set; }
        public bool EmploymentContract { get; set; }

    }

     public class UpdateMigrationDto
    {
        


        public int CountryId { get; set; }


        // public MigrationStatusDto? MigrationStatus { get; set; }



        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }
        public string? Profession { get; set; }
        public bool EmploymentContract { get; set; }



    }

} 
    