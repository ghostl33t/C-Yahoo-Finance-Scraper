using Microsoft.EntityFrameworkCore;
using Scraper_NetCore.Models.Domain;

namespace Scraper_NetCore.Data;

public class DBMainContext : DbContext
{
    public DBMainContext(DbContextOptions<DBMainContext> options) : base(options)
    {

    }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyItem> CompanyItems { get; set; }
}
