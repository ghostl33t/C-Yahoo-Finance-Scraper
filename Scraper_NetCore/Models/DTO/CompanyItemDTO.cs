namespace Scraper_NetCore.Models.DTO;
public class CompanyItemDTO
{
    public DateTime Date { get; set; } = DateTime.Today;
    public string PreviousClosePrice { get; set; } = string.Empty;
    public string OpenPrice { get; set; } = string.Empty;
    public long CompanyId { get; set; } = 0;
}
