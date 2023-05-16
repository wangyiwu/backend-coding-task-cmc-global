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
                    Latitude = 0,
                    Longitude = 0,
                }
            },
            new Ship()
            {
                Id = Guid.NewGuid(),
                Name = "Ship 2",
                Position = new Position()
                {
                    Latitude = 169,
                    Longitude = 22,
                }
            },
            new Ship()
            {
                Id = Guid.NewGuid(),
                Name = "Ship 3",
                Position = new Position()
                {
                    Latitude = 123,
                    Longitude = 23,
                }
            },
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
                    Longitude = 114.17306035954454,
                    Latitude =  22.284057934138204
                },
                Name = "Victoria Harbour",
            },
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude =114.14768122090493,
                    Latitude =   22.245156286086612
                },
                Name = "Aberdeen Harbour",
            },
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude =  114.20621508465587,
                    Latitude =  22.284057934138204
                },
                Name = "Double Haven ",
            },
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude = 116.17306035954454,
                    Latitude =  22.284057934138204
                },
                Name = "Port Shelter",
            },
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude = 119.17306035954454,
                    Latitude =  22.284057934138204
                },
                Name = "Inner Port Shelter",
            },
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude = 112.17306035954454,
                    Latitude =  22.284057934138204
                },
                Name = "Tolo Harbour",
            },
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude = 155.17306035954454,
                    Latitude =  22.284057934138204
                },
                Name = "Tai Tam Harbour",
            }
        };
    }
}
