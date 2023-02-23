using Scraper_NetCore.Models.Domain;

namespace Scraper_NetCore.Repositories.Interfaces;

public interface ICompanyCreate
{
    public Task<bool> CreateCompanyAsync(Company newCompany); 
}
