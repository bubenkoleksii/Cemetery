namespace Cemetery.Models.Request;

public class CemeteryRequest
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public int Year { get; set; }
    public int CountOfBurial { get; set; }
}
