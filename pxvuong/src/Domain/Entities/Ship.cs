using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Ship
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Velocity { get; set; }
    public Position Position { get; set; }
}
