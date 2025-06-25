using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ApplyWhatILearn.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplyWhatILearn.ViewModel
{
    public class InstructorCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImagUrl { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int? DeptId { get; set; }
        [Required]
        public int CrsId { get; set; }
        public List<Department> DeptList { get; set; }
        public List<Course> CrsList { get; set; }


    }
}
