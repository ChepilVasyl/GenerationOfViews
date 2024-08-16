using System.ComponentModel.DataAnnotations;
namespace SecondAttempt.Models.MyModels;

public class Teacher
{
    [Key] 
    public int Id { set; get; }

    public string Name { set; get; }

    public string Surname { set; get; }

    public List<Student> Students { set; get; } = new List<Student>();
    
    public List<Subject> Subjects { set; get; } = new List<Subject>();
}