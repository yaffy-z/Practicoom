using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManagment.Core.Models;

namespace WorkersManagment.Core.Services
{
    public interface IPositionWorkerService
    {
        Task<PositionWorker> AddPositionToWorkerAsync(int workerId, PositionWorker positionWorker);
        Task<PositionWorker> UpdatePositionToWorkerAsync(int workerId, int positionId, PositionWorker positionWorker);

        Task<bool> DeletePositionOfWorkerAsync(int workerId, int positionId);
        Task<IEnumerable<PositionWorker>> GetWorkerPositionsAsync(int workerId);
    }
}
