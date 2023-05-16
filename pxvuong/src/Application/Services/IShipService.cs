﻿using Application.Models.Ship;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public interface IShipService
{
    public Task<Ship> CreateShip(CreateShipRequest request);
    public Task<IEnumerable<Ship>> GetShips();
    public Task<Ship> UpdateVelocity(string id, UpdateVelocityRequest request);
}