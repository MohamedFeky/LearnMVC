using System.ComponentModel.DataAnnotations;
using ApplyWhatILearn.Models;

namespace ApplyWhatILearn.ViewModel
{
    public class CourseCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string MinDegree { get; set; }
        [Required]
        public string Hours { get; set; }
        [Required]
        public int DeptId { get; set; }

        public List<Department> DeptList { get; set; }

    }
}
