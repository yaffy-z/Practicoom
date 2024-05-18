using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManagment.Core.Models;
using WorkersManagment.Core.Repositories;

namespace WorkersManagment.Data.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly DataContext _context;
        public WorkerRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Worker> AddWorkerAsync(Worker worker)
        {
            if (_context.Workers.Any(w => w.Identity == worker.Identity))
            {
                throw new Exception("עובד עם מספר זיהוי זהה כבר קיים ברשימה.");
            }
            else
            {
                await _context.Workers.AddAsync(worker);
                await _context.SaveChangesAsync();
            }


            //_context.Workers.AddAsync(worker);
            //await _context.SaveChangesAsync();
            return worker;
        }

        public async Task<bool> DeleteEmployeeAsync(int workerId)
        {
            var worker = await _context.Workers.FirstOrDefaultAsync(e => e.WorkerId == workerId);

            if (worker != null)
            {
                worker.StatusActive = false;
                await _context.SaveChangesAsync();
                return true; // המחיקה והעדכון בוצעו בהצלחה
            }

            return false; // העובד לא נמצא במסד הנתונים
        }



        public async Task<IEnumerable<Worker>> GetWorkerAsync()
        {
            var workers = await _context.Workers.Include(w=>w.PositionWorkers.Where(active=>active.StatusActive==true)).ToListAsync();
            var filteredWorkers = workers.Where(w => w.StatusActive == true).ToList();
            
                
            return filteredWorkers;
        }

        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
            var worker= await _context.Workers.FirstOrDefaultAsync(w=>w.WorkerId == id);
            var positions = await _context.PositionsWorker
                    .Where(emp => emp.WorkerId == id && emp.StatusActive).ToListAsync();
                    
            if (positions != null)
            {
                worker.PositionWorkers = positions;
            }
            return worker;
        }
        public async Task<IEnumerable<Worker>> GetWorkersAsync()
        {
            return await _context.Workers.ToListAsync();
        }


        public async Task<Worker> UpdateWorkerAsync(int id, Worker updatedWorker)
        {
            var worker = await _context.Workers.Include(w => w.PositionWorkers).FirstOrDefaultAsync(e => e.WorkerId == id);
            if (worker == null)
            {
                return null;
            }
            if (_context.Workers.Any(w => w.Identity == worker.Identity&&w.WorkerId!=worker.WorkerId))
            {
                throw new Exception("עובד עם מספר זיהוי זהה כבר קיים ברשימה.");
            }
            worker.FirstName = updatedWorker.FirstName;
            worker.LastName = updatedWorker.LastName;
            worker.Identity = updatedWorker.Identity;
            worker.Gender = updatedWorker.Gender;
            worker.BirthDate = updatedWorker.BirthDate;
            worker.StatusActive = updatedWorker.StatusActive;
            worker.EntryDate = updatedWorker.EntryDate;
            worker.PositionWorkers = updatedWorker.PositionWorkers;
            //for (int i = 0; i < updatedWorker.PositionWorkers.Count; i++)
            //{
            //    if (worker.PositionWorkers != null)
            //    {
            //        PositionWorker positionWorkerCheck = updatedWorker.PositionWorkers.FirstOrDefault(p => p.PositionId == worker.PositionWorkers[i].PositionId);
            //        if (positionWorkerCheck != null)
            //        {
            //            worker.PositionWorkers[i].StatusActive = positionWorkerCheck.StatusActive;
            //            worker.PositionWorkers[i].IsManagement = positionWorkerCheck.IsManagement;
            //            worker.PositionWorkers[i].EntryDate = positionWorkerCheck.EntryDate;
            //        }
            //    }

            //    else
            //        worker.PositionWorkers.Add(updatedWorker.PositionWorkers[i]);
            //}
            //for (int i = 0; i < updatedWorker.PositionWorkers.Count; i++)
            //{
            //    if (worker.PositionWorkers != null)
            //    {

            //        PositionWorker positionWorkerCheck = updatedWorker.PositionWorkers[i];
            //            if (positionWorkerCheck != null)
            //            {
            //                worker.PositionWorkers[i].StatusActive = positionWorkerCheck.StatusActive;
            //                worker.PositionWorkers[i].IsManagement = positionWorkerCheck.IsManagement;
            //                worker.PositionWorkers[i].EntryDate = positionWorkerCheck.EntryDate;
            //            }
                    
            //    }
            //    else
            //    {
            //        worker.PositionWorkers=updatedWorker.PositionWorkers;
            //    }
            //}
            await _context.SaveChangesAsync();

            return worker;
        }
    }
}
