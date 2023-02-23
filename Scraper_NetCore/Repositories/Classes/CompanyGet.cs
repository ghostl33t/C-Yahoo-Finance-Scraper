using Microsoft.EntityFrameworkCore;
using Scraper_NetCore.Data;
using Scraper_NetCore.Models.Domain;
using Scraper_NetCore.Repositories.Interfaces;

namespace Scraper_NetCore.Repositories.Classes;
public class CompanyGet : ICompanyGet
{
    private readonly DBMainContext _dbMain;
    public CompanyGet(DBMainContext dbMain)
    { 
        _dbMain = dbMain;
    }
    public async Task<List<Company>> GetAllCompaniesAsync()
    {
        try
        {
            return await _dbMain.Companies.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<long> GetCompanyByTickerAsync(string ticker)
    {
        try
        {
            var company = await _dbMain.Companies.FirstOrDefaultAsync(s => s.Ticker == ticker);
            if(company != null)
            {
                return company.Id;
            }
            return 0;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
