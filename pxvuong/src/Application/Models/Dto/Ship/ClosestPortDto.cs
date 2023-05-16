using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dto.Ship;

public class ClosestPortDto
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public double Distance { get; set; }
    public double ArrivalTime { get; set; }
}
