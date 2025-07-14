using ApplyWhatILearn.Models;
using ApplyWhatILearn.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;
        public InstructorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public IActionResult ShowAll()
        {
            List<Instructor> instructorsList = _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .ToList();
            return View("showall", instructorsList);
        }

        public IActionResult ShowUser(int id)
        {
            Instructor instructor = _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefault(i => i.Id == id);
            return View("showuser", instructor);
        }


        public IActionResult Edite(int id)
        {
            Instructor instructor = _context.Instructors.FirstOrDefault(i => i.Id == id);
            var instructorViewModel = _mapper.Map<InstructorCreateViewModel>(instructor);
            instructorViewModel.DeptList = _context.Departments.ToList();
            instructorViewModel.CrsList = _context.Courses.ToList();
            return View("Edite", instructorViewModel);
        }
        
        [HttpPost]
        public IActionResult Edite(int id, InstructorCreateViewModel instFromRequest)
        {
            if(instFromRequest.Name != null)
            {
                Instructor instructorModel = _context.Instructors.FirstOrDefault(i => i.Id == id);

                _mapper.Map(instFromRequest, instructorModel);
                _context.Instructors.Update(instructorModel);
                _context.SaveChanges();
                return RedirectToAction("ShowUser", new { id = instructorModel.Id });
            }

            instFromRequest.DeptList = _context.Departments.ToList();
            instFromRequest.CrsList = _context.Courses.ToList();
            return View("Edite", instFromRequest);

        }



        // ========== GET ==========
        public IActionResult Create()
        {
            InstructorCreateViewModel instructorViewModel = new InstructorCreateViewModel
            {
                DeptList = _context.Departments.ToList(),
                CrsList = _context.Courses.ToList()
            };

            return View("Create", instructorViewModel);
        }

        // ========== POST ==========

        [HttpPost]
        public IActionResult Create(InstructorCreateViewModel instructorFromRequest)
        {

            if (instructorFromRequest != null)
            {
                Instructor instructor = _mapper.Map<Instructor>(instructorFromRequest);
                _context.Instructors.Add(instructor);
                _context.SaveChanges();

                return RedirectToAction("ShowUser", new { id = instructor.Id });
            }

            instructorFromRequest.DeptList = _context.Departments.ToList();
            instructorFromRequest.CrsList = _context.Courses.ToList();
            return View("Create", instructorFromRequest);

        }
    }
}
