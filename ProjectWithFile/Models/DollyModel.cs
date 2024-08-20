using System.ComponentModel.DataAnnotations;

namespace ProjectWithFile.Models;

public class DollyModel
{
    [Key]
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Color { get; set; }
    public string? Url { get; set; }
}