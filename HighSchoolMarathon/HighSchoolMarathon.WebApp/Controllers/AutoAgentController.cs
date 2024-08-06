using AutoMapper;
using HighSchoolMarathon.DataAccess.Models;
using HighSchoolMarathon.DataAccess.Repositories;
using HighSchoolMarathon.WebApp.Infrastructure;
using HighSchoolMarathon.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HighSchoolMarathon.WebApp.Controllers
{
    public class AutoAgentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHubContext<MarathonEventHub> _hubContext;
        private readonly IRunnerRepository _runnerRepository;
        private readonly IEventRepository _eventRepository;

        public AutoAgentController(IMapper mapper, IHubContext<MarathonEventHub> hubContext, IRunnerRepository runnerRepository, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _hubContext = hubContext;
            _runnerRepository = runnerRepository;
            _eventRepository = eventRepository;
        }

        public IRunnerRepository Get_runnerRepository()
        {
            return _runnerRepository;
        }

        // Method to be called by the background service
        public async Task SendUpdateNotification(IRunnerRepository _runnerRepository)
        {
            var activeEvent = await _eventRepository.GetActiveEventAsync();
            if (activeEvent == null)
            {
                return;
            }

            var runners = await _runnerRepository.GetAllRunnerAsync(activeEvent.Id);
            Random random = new Random();

            // Method to randomly change the rank of runners
            var maleRunner = runners.Where(r => r.Gender == "Male").ToList();
            int newIndex = random.Next(maleRunner.Count);
            if (newIndex > 1)
            {
                RunnerRegistration temp = maleRunner[newIndex];
                maleRunner[newIndex].Ranking = newIndex - 1;
                maleRunner[newIndex] = maleRunner[newIndex - 1];
                maleRunner[newIndex - 1] = temp;
                maleRunner[newIndex - 1].Ranking = newIndex;
                _ = _runnerRepository.UpdateRunnerRank(maleRunner[newIndex]);
                _ = _runnerRepository.UpdateRunnerRank(maleRunner[newIndex - 1]);
            }

            // Method to randomly change the rank of runners
            var femaleRunner = runners.Where(r => r.Gender == "Female").ToList();
            newIndex = random.Next(femaleRunner.Count);
            if (newIndex > 1)
            {
                RunnerRegistration temp = femaleRunner[newIndex];
                femaleRunner[newIndex].Ranking = newIndex - 1;
                femaleRunner[newIndex] = femaleRunner[newIndex - 1];
                femaleRunner[newIndex - 1] = temp;
                femaleRunner[newIndex - 1].Ranking = newIndex;
                _ = _runnerRepository.UpdateRunnerRank(femaleRunner[newIndex]);
                _ = _runnerRepository.UpdateRunnerRank(femaleRunner[newIndex - 1]);
            }

            var rankingModel = _mapper.Map<List<RankingModel>>(runners.Take(3).Union(femaleRunner.Take(3)));
            // Serialize the list of runners to a JSON string
            var rankingJson = JsonConvert.SerializeObject(rankingModel);

            // Send the JSON string to all connected clients
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", rankingJson);

        }
    }
}
