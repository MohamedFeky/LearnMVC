namespace ApplyWhatILearn.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public string MinDegree { get; set; }
        public string Hours { get; set; }

        public int DeptId { get; set; }

        public Department Department { get; set; }

        public List<Instructor> Instructors { get; set; }
        public List<CrsResult> CrsResults { get; set; }
    }
}
