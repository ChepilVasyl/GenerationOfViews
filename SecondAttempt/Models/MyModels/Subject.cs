using System.ComponentModel.DataAnnotations;
namespace SecondAttempt.Models.MyModels;

public class Subject
{
    [Key]
    public int Id { set; get; }
    
    public string Name { set; get; }

    public List<Student> Students { set; get; } = new List<Student>();
    
    public List<Teacher> Teachers { set; get; } = new List<Teacher>();
}