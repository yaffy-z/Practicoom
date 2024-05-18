using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManagment.Core.Models;

namespace WorkersManagment.Core.Repositories
{
    public interface IPositionWorkerRepository
    {
        Task<IEnumerable<PositionWorker>> GetWorkerPositionsAsync(int employeeId);
        Task<PositionWorker> AddPositionToWorkerAsync(PositionWorker positionWorker);
        //Task<PositionWorker> UpdatePositionToWorkerAsync(PositionWorker OldPositionWorker, PositionWorker positionWorkerToUpdate);
        //Task<bool> DeletePositionOfWorkerAsync( int positionId);
       
    }
}
