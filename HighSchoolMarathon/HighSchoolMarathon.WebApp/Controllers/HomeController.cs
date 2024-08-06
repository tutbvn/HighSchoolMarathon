using AutoMapper;
using HighSchoolMarathon.DataAccess.Repositories;
using HighSchoolMarathon.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HighSchoolMarathon.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IRunnerRepository _runnerRepository;

        public HomeController(IMapper mapper, IEventRepository eventRepository, IRunnerRepository runnerRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _runnerRepository = runnerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<EventModel>>(events);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
