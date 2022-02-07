namespace BlazorWebAssemblyDemo.Shared.Models;

public class Country
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Abbreviation { get; set; }

    public string Capital { get; set; }

    public string Currency { get; set; }

    public string Phone { get; set; }

    public Media Media { get; set; } = new();
}
