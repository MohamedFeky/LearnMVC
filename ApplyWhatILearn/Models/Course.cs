using System.ComponentModel.DataAnnotations;

namespace ApplyWhatILearn.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]

        public string Name { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        [Range(45,55)]
        public string MinDegree { get; set; }
        public string Hours { get; set; }

        public int DeptId { get; set; }

        public Department Department { get; set; }

        public List<Instructor> Instructors { get; set; }
        public List<CrsResult> CrsResults { get; set; }
    }
}
