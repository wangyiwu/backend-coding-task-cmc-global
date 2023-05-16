using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Ship;

public class CreateShipRequest
{
    public string Name { get; set; }
    public Position Position { get; set; }
}
