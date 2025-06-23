using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ApplyWhatILearn.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagUrl { get; set; }
        public string Address { get; set; }
        public string Grade { get; set; }

        public int DeptId { get; set; }
        public Department Department { get; set; }

        public List<CrsResult> CrsResults { get; set; }
    }
}
