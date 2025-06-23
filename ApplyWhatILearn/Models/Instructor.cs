namespace ApplyWhatILearn.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagUrl { get; set; }
        public string Salary { get; set; }
        public string Address { get; set; }

        public int DeptId { get; set; } //FK
        public int CrsID { get; set; }
        public Department Department { get; set; } // navigation property
        public Course Course { get; set; }
    }
}
