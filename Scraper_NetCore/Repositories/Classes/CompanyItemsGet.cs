using Microsoft.EntityFrameworkCore;
using Scraper_NetCore.Data;
using Scraper_NetCore.Models.Domain;
using Scraper_NetCore.Repositories.Interfaces;

namespace Scraper_NetCore.Repositories.Classes;
public class CompanyItemsGet : ICompanyItemsGet
{
    private readonly DBMainContext _dbMain;
    public CompanyItemsGet(DBMainContext dbMain)
    {
        _dbMain = dbMain;
    }
    public async Task<List<CompanyItem>> GetItemsByTicker(long companyId)
    {
        try
        {
             return await _dbMain.CompanyItems.Where(s => s.CompanyId == companyId).ToListAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
