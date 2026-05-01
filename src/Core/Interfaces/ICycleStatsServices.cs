using System;
using System.Linq.Expressions;
using Core.Entities;
using Core.DTOs;


namespace Core.Interfaces;

public interface ICycleStatsServices 
{
    Task<IEnumerable<PressureStatsDto>> CyclePressureIncomplet();
}
