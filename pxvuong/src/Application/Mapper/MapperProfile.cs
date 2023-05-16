﻿using Application.Models.RequestModel.Ship;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<CreateShipRequest, Ship>().ReverseMap();
    }
}
