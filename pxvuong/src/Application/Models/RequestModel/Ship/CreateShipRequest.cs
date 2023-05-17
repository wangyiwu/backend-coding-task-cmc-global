using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.RequestModel.Ship;

public class CreateShipRequest
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public double Velocity { get; set; }
}
