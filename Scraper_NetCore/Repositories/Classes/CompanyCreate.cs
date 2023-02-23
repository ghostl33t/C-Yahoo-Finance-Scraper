using Scraper_NetCore.Data;
using Scraper_NetCore.Models.Domain;
using Scraper_NetCore.Repositories.Interfaces;

namespace Scraper_NetCore.Repositories.Classes;
public class CompanyCreate : ICompanyCreate
{
	private readonly DBMainContext _dbMain;
	public CompanyCreate(DBMainContext dbMain)
	{
		_dbMain = dbMain;
	}
    public async Task<bool> CreateCompanyAsync(Company newCompany)
    {
		try
		{
            await _dbMain.AddAsync(newCompany);
			await _dbMain.SaveChangesAsync();
			return true;

        }
		catch (Exception)
		{

			throw;
		}
    }
}
