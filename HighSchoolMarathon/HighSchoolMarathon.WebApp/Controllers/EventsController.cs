using AutoMapper;
using HighSchoolMarathon.DataAccess.Models;
using HighSchoolMarathon.DataAccess.Repositories;
using HighSchoolMarathon.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolMarathon.WebApp.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IRunnerRepository _runnerRepository;

        public EventsController(IMapper mapper, IEventRepository eventRepository, IRunnerRepository runnerRepository)
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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventModel model)
        {
            if (ModelState.IsValid)
            {
                var eventEntity = _mapper.Map<RunningEvent>(model);
                eventEntity.Status = "Open";
                await _eventRepository.AddAsync(eventEntity);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(id);
            if (eventEntity == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<EventModel>(eventEntity);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventModel model)
        {
            if (ModelState.IsValid)
            {
                var eventEntity = _mapper.Map<RunningEvent>(model);
                await _eventRepository.UpdateAsync(eventEntity);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Register(int eventId)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);
            if (eventEntity == null)
            {
                return NotFound();
            }

            var model = new RegistrationModel
            {
                RunningEventId = eventEntity.Id
            };

            return View(model);
        }

        private async Task<string> GenerateBibNumber(string gender, int age)
        {
            // Example: Generate a random 6-digit number
            do
            {
                var random = new Random();
                var bidNumber = $"{gender.ToUpper().Substring(0, 1)}{age.ToString("00")}.{random.Next(0, 9999).ToString("0000")}";
                var runnerRegister = await _runnerRepository.GetByBibNumberAsync(bidNumber);
                if (runnerRegister == null)
                {
                    return bidNumber;
                }
            }
            while (true);

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                model.Ranking = random.Next(10);
                model.BibNumber = await GenerateBibNumber(model.Gender, model.Age);
                var registration = _mapper.Map<RunnerRegistration>(model);
                await _runnerRepository.RegisterEventAsync(registration);

                return View("RegisterResult", model);
            }

            return View(model);
        }


        [AllowAnonymous]
        public async Task<IActionResult> RegisterResult(string bidNumber)
        {
            var runnerRegister = await _runnerRepository.GetByBibNumberAsync(bidNumber);
            if (runnerRegister == null)
            {
                return NotFound();
            }

            var registerModel = _mapper.Map<RegistrationModel>(runnerRegister);

            return View(registerModel);
        }
    }
}
