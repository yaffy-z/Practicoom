﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManagment.Core.Models;
using WorkersManagment.Core.Repositories;
using WorkersManagment.Core.Services;

namespace WorkersManagment.Service.Services
{
    public class PositionService:IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;

        }
        public async Task<Position> AddPositionAsync(Position position)
        {
            return await _positionRepository.AddPositionAsync(position);
        }
        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await _positionRepository.GetPositionsAsync();
        }
    }
}
