using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scraper_NetCore.Models.Domain;

public class Company
{
    [Key]
    public long Id { get; set; }
    [Column(TypeName ="nvarchar")]
    [MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar")]
    [MaxLength(10)]
    public string Ticker { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    public string Employees { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar")]
    [MaxLength(4000)]
    public string Adress { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    public string MarketCap { get; set; } = string.Empty;
}
