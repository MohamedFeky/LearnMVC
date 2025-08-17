using ApplyWhatILearn.Models;
using ApplyWhatILearn.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.Controllers
{
    public class TraineeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TraineeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowResult(int id, int crsId)
        {
            CrsResult result = _context.CrsResults
                .Include(r => r.Course)
                .Include(r => r.Trainee)
                .FirstOrDefault(r => r.TraineeId == id && r.CrsId == crsId);
            if (result == null)
                return NotFound();

            var showCrsResult = _mapper.Map<ShowCrsResultViewModel>(result);

            return View("ShowResult", showCrsResult);
        }
    }
}
