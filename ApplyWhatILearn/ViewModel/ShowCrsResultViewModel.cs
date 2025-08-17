using ApplyWhatILearn.Models;

namespace ApplyWhatILearn.ViewModel
{
    public class ShowCrsResultViewModel
    {
        public int Id { get; set; }
        public string Degree { get; set; }

        public int CrsId { get; set; }
        public int TraineeId { get; set; }

        public string CourseName { get; set; }
        public string TraineeName { get; set; }

        public string MinDegree { get; set; }
        public string Color
        {
            get
            {
                int degreeValue = 0;
                int minDegreeValue = 0;

                int.TryParse(Degree, out degreeValue);
                int.TryParse(MinDegree, out minDegreeValue);

                if (degreeValue >= minDegreeValue)
                    return "green";   
                else
                    return "red";   
            }
        }

    }
}
