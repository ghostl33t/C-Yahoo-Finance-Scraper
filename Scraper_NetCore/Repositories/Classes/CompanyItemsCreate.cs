using Scraper_NetCore.Data;
using Scraper_NetCore.Models.Domain;
using Scraper_NetCore.Repositories.Interfaces;

namespace Scraper_NetCore.Repositories.Classes;
public class CompanyItemsCreate : ICompanyItemsCreate
{
    private readonly DBMainContext _dbMain;
    public CompanyItemsCreate(DBMainContext dbMain)
    {
        _dbMain = dbMain;
    }
    public async Task<bool> CreateCompanyItemAsync(CompanyItem newItem)
    {
        try
        {
            await _dbMain.AddAsync(newItem);
            await _dbMain.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
