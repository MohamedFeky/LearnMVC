using ApplyWhatILearn.Models;
using ApplyWhatILearn.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CourseController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ShowCourse(int id)
        {
            Course course = _context.Courses
                .Include(i => i.Department)
                .FirstOrDefault(i => i.Id == id);
            return View("ShowCourse", course);
        }

        public IActionResult ShowAllCourses()
        {
            List<Course> coursesList = _context.Courses
                .Include(i => i.Department)
                .ToList();
            return View("ShowAllCourses", coursesList);
        }


        public IActionResult CreateCourse()
        {
            CourseCreateViewModel courseCreateViewModel = new CourseCreateViewModel
            {
                DeptList = _context.Departments.ToList()
            };
            return View("CreateCourse", courseCreateViewModel);
        }

        [HttpPost]
        public IActionResult CreateCourse(CourseCreateViewModel CrsFromRequest)
        {
            if(CrsFromRequest != null)
            {
                Course course = _mapper.Map<Course>(CrsFromRequest);
                _context.Courses.Add(course);
                _context.SaveChanges();

                return RedirectToAction("ShowCourse", new { id = course.Id });
            }
            CrsFromRequest.DeptList = _context.Departments.ToList();

            return View("CreateCourse", CrsFromRequest);
        }
    }
}
