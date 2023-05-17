using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public static class PortSeedData
{
    public static List<Ship> SeedShipData()
    {
        return new List<Ship>()
        {
            new Ship()
            {
                Id = Guid.NewGuid(),
                Name = "Ship 1",
                Position = new Position()
                {
                    Latitude = 22,
                    Longitude = 113,
                }
            },
            new Ship()
            {
                Id = Guid.NewGuid(),
                Name = "Ship 2",
                Position = new Position()
                {
                    Latitude = 20,
                    Longitude = 114,
                }
            }
        };

    }

    public static List<Port> SeedPortData()
    {
        return new List<Port>()
        {
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude = 116,
                    Latitude =  20
                },
                Name = "Victoria Harbour",
            },
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude =112,
                    Latitude =   22
                },
                Name = "Aberdeen Harbour",
            }
        };
    }
}
