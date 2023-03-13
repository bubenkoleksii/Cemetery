﻿namespace Cemetery.Models.Response;

public class CemeteryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public int Year { get; set; }
    public int CountOfBurial { get; set; }
}
