using Scraper_NetCore.Models.Domain;

namespace Scraper_NetCore.Repositories.Interfaces;
public interface ICompanyItemsCreate
{
    public Task<bool> CreateCompanyItemAsync(CompanyItem newItem);
}
