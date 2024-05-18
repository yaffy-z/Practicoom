using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManagment.Core.Models;
using WorkersManagment.Core.Repositories;
using static WorkersManagment.Data.Repositories.PositionWorkerRepository;

namespace WorkersManagment.Data.Repositories
{
    public class PositionWorkerRepository:IPositionWorkerRepository
    {
       
            private readonly DataContext _context;
            public PositionWorkerRepository(DataContext context)
            {
                _context = context;
            }
            public async Task<PositionWorker> AddPositionToWorkerAsync(PositionWorker positionWorker)
            {
                await _context.PositionsWorker.AddAsync(positionWorker);
                _context.SaveChanges();
                return positionWorker;
            }
            public async Task<PositionWorker> UpdatePositionToWorkerAsync(PositionWorker OldPositionWorker, PositionWorker positionWorkerToUpdate)
            {
           
            //OldPositionWorker.PositionId= positionWorkerToUpdate.PositionId;
            OldPositionWorker.StatusActive=positionWorkerToUpdate.StatusActive;
            OldPositionWorker.EntryDate= positionWorkerToUpdate.EntryDate;
            OldPositionWorker.IsManagement=positionWorkerToUpdate.IsManagement;
            await _context.SaveChangesAsync();
                return OldPositionWorker;
            }

            public async Task<bool> DeletePositionOfWorkerAsync(int positionId)
            {
                var positionWorker = await _context.PositionsWorker.FirstOrDefaultAsync(e =>  e.PositionId == positionId);

                if (positionWorker != null)
                {
                    positionWorker.StatusActive = false;
                    await _context.SaveChangesAsync();
                    return true; // המחיקה והעדכון בוצעו בהצלחה
                }

                return false; // העובד לא נמצא במסד הנתונים
            }
            public async Task<IEnumerable<PositionWorker>> GetWorkerPositionsAsync(int WorkerId)
            {
                return await _context.PositionsWorker.Where(e => e.WorkerId == WorkerId && e.StatusActive).ToListAsync();
            }

     
    }
    
}
