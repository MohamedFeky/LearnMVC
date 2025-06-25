using ApplyWhatILearn.Models;
using ApplyWhatILearn.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.Controllers
{
    public class InstructorController : Controller
    {
        public AppDbContext context = new AppDbContext();
         
        private readonly IMapper _mapper;
       // private readonly AppDbContext _context;

        public InstructorController(IMapper mapper)
        {
            _mapper = mapper;

        }
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


        public IActionResult Edite(int id)
        {
            Instructor instructor = context.Instructors.FirstOrDefault(i => i.Id == id);
            var instructorViewModel = _mapper.Map<InstructorCreateViewModel>(instructor);
            instructorViewModel.DeptList = context.Departments.ToList();
            instructorViewModel.CrsList = context.Courses.ToList();
            return View("Edite", instructorViewModel);
        }
        
        [HttpPost]
        public IActionResult Edite(int id, InstructorCreateViewModel instFromRequest)
        {
            if(instFromRequest.Name != null)
            {
                var instructorModel = context.Instructors.FirstOrDefault(i => i.Id == id);

                _mapper.Map(instFromRequest, instructorModel);
                context.Instructors.Update(instructorModel);
                context.SaveChanges();
                return RedirectToAction("ShowUser", new { id = instructorModel.Id });
            }

            instFromRequest.DeptList = context.Departments.ToList();
            instFromRequest.CrsList = context.Courses.ToList();
            return View("Edite", instFromRequest);

        }



        // ========== GET ==========
        public IActionResult Create()
        {
            InstructorCreateViewModel instructorViewModel = new InstructorCreateViewModel
            {
                DeptList = context.Departments.ToList(),
                CrsList = context.Courses.ToList()
            };

            return View("Create", instructorViewModel);
        }

        // ========== POST ==========

        [HttpPost]
        public IActionResult Create(InstructorCreateViewModel instructorFromRequest)
        {

            if (instructorFromRequest != null)
            {
                var instructor = _mapper.Map<Instructor>(instructorFromRequest);
                context.Instructors.Add(instructor);
                context.SaveChanges();

                return RedirectToAction("ShowUser", new { id = instructor.Id });
            }

            instructorFromRequest.DeptList = context.Departments.ToList();
            instructorFromRequest.CrsList = context.Courses.ToList();
            return View("Create", instructorFromRequest);

        }
    }
}
