using ApplyWhatILearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.Controllers
{
    public class InstructorController : Controller
    {
        public AppDbContext context = new AppDbContext();

        public IActionResult ShowAll()
        {
            List<Instructor> instructorsList = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .ToList();
            return View("showall", instructorsList);
        }

        public IActionResult ShowUser(int id)
        {
            Instructor instructor = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefault(i => i.Id == id);
            return View("showuser", instructor);
        }
    }
}
