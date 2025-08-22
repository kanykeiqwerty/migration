using System.ComponentModel.DataAnnotations;

namespace MigrationApi.Models
{
    public class Migration
    {
        public Guid Id { get; set; }
        public Guid CitizenFormID { get; set; }
        public CitizenForm? CitizenForm { get; set; }
        public int CountryID { get; set; }
        public Country? Country { get; set; }

        


        [DataType(DataType.Date)]
        public DateOnly DepartureDate { get; set; }
        [DataType(DataType.Date)]
        public DateOnly ReturnDate { get; set; }
        public string? Profession { get; set; }
        public bool EmploymentContract { get; set; }

        

    }
}