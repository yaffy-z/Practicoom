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
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _WorkerRepository;
        public WorkerService(IWorkerRepository workerRepository)
        {
            _WorkerRepository = workerRepository;
        }
        public async Task<Worker> AddWorkerAsync(Worker worker)
        {
           return await _WorkerRepository.AddWorkerAsync(worker);
        }

        public async Task<bool> DeleteWorkerAsync(int id)
        {
            return await _WorkerRepository.DeleteEmployeeAsync(id);
        }

        public async Task<IEnumerable<Worker>> GetWorkerAsync()
        {
            return await _WorkerRepository.GetWorkerAsync();
        }

        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
           return await _WorkerRepository.GetWorkerByIdAsync(id);
        }

        public async Task<Worker> UpdateWorkerAsync(int id, Worker worker)
        {
            return await _WorkerRepository.UpdateWorkerAsync(id, worker);
        }
    }
}
