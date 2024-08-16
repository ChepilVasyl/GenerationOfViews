using System.ComponentModel.DataAnnotations;

namespace SecondAttempt.Models.MyModels;

public class Student
{
    [Key]
    public int Id { set; get; }
    
    public string Name { set; get; }
    
    public int Age { set; get; }
    
    public List<Teacher> Teachers { set; get; } = new List<Teacher>();
    public List<Subject> Subjects { set; get; } = new List<Subject>();
}