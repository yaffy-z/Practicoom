using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManagment.Core.Models;
using WorkersManagment.Core.Repositories;
using WorkersManagment.Core.Services;

namespace WorkersManagment.Service.Services
{
    public class PositionWorkerService : IPositionWorkerRepository
    {
        private readonly IPositionWorkerRepository _positionWorkerRepository;
        public PositionWorkerService(IPositionWorkerRepository positionWorkerRepository)
        {
            _positionWorkerRepository = positionWorkerRepository;
        }
        public async Task<PositionWorker> AddPositionToWorkerAsync(PositionWorker positionWorker)
        {
            return await _positionWorkerRepository.AddPositionToWorkerAsync(positionWorker);
        }

        public async Task<IEnumerable<PositionWorker>> GetWorkerPositionsAsync(int workerId)
        {
            return await _positionWorkerRepository.GetWorkerPositionsAsync(workerId);
        }
    }
}
