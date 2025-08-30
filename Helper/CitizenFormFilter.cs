using MigrationApi.Dto;
using MigrationApi.Models;
using Microsoft.EntityFrameworkCore;
namespace MigrationApi.Helper
{
    public static class CitizenFormFilter
{
    public static IQueryable<CitizenForm> ApplyFilter(
        this IQueryable<CitizenForm> query, CitizenFormFilterDto filter)
    {
        if (filter.RegistrationDateFrom.HasValue)
            query = query.Where(f => f.RegistrationDate >= filter.RegistrationDateFrom.Value);

        if (filter.RegistrationDateTo.HasValue)
            query = query.Where(f => f.RegistrationDate <= filter.RegistrationDateTo.Value);
          
    if (filter.BirthYear.HasValue)
{
    int year = filter.BirthYear.Value;
    query = query.Where(f => f.BirthDate.Year == year);
}

        if (!string.IsNullOrEmpty(filter.Pin))
                query = query.Where(f => f.PIN.Contains(filter.Pin));

        if (!string.IsNullOrEmpty(filter.FullName))
            {
    var fullName = filter.FullName.Trim();
    query = query.Where(f => 
        (f.FirstName + " " + f.LastName).Contains(fullName)
        || f.FirstName.Contains(fullName)
        || f.LastName.Contains(fullName));
}

        if (filter.BirthDate.HasValue)
            query = query.Where(f => f.BirthDate == filter.BirthDate.Value); // ⚡ теперь работает

        if (filter.Gender.HasValue)
            query = query.Where(f => f.Gender == filter.Gender.Value);

        if (!string.IsNullOrEmpty(filter.Region))
            query = query.Where(f => f.District.Region.Name.Contains(filter.Region));

        if (!string.IsNullOrEmpty(filter.District))
            query = query.Where(f => f.District.Name.Contains(filter.District));

        if (!string.IsNullOrEmpty(filter.MigrationCountry))
            query = query.Where(f => f.Migrations.Any(m => m.Country.Name.Contains(filter.MigrationCountry)));

        if (filter.DepartureDate.HasValue)
            query = query.Where(f => f.Migrations.Any(m => m.DepartureDate == filter.DepartureDate.Value));

            if (filter.IsArchived.HasValue)
            query = query.Where(f => f.IsArchived == filter.IsArchived.Value);

            
        return query;
    }
}

}