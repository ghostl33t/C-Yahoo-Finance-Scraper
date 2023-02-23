using Scraper_NetCore.Models.Domain;

namespace Scraper_NetCore.Repositories.Interfaces;
public interface ICompanyGet
{
    public Task<List<Company>> GetAllCompaniesAsync();
    public Task<long> GetCompanyByTickerAsync(string ticker);
}
