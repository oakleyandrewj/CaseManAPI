namespace CaseManAPI.Models;

public class Client
{
    public int Id { get; set; } 
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? Initial { get; set; }
    public string? Salutation { get; set; }
    public string? Title { get; set; }
    public string? HomeTel { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? PrefContact { get; set; }
    public bool IsClientIDChecked { get; set; }
}