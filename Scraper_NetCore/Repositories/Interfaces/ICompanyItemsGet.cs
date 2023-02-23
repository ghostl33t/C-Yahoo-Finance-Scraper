using Scraper_NetCore.Models.Domain;

namespace Scraper_NetCore.Repositories.Interfaces;
public interface ICompanyItemsGet
{
    public Task<List<CompanyItem>> GetItemsByTicker(long companyId);
}
