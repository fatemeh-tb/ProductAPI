namespace ThriveProductShop.models.ProductDomain.External;

public class productDto
{
    public int Id     { get; set; }
    public string Name { get; set; }
    public int? ProductGroupId { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public decimal? Price { get; set; }
}