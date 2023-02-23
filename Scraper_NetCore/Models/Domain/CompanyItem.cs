using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scraper_NetCore.Models.Domain;
public class CompanyItem
{
    [Key]
    public long Id { get; set; }
    [Column(TypeName ="datetime")]
    public DateTime Date { get; set; } = DateTime.Today;
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    public string PreviousClosePrice { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    public string OpenPrice { get; set; } = string.Empty;
    public long CompanyId { get; set; } = 0;

}
