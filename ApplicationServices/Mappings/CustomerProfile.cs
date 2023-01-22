﻿using AutoMapper;
using CreditApplications.ApplicationServices.Domain.Models;

namespace CreditApplications.ApplicationServices.Mappings;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<DataAccess.Entities.Customer, Domain.Models.Customer>();
        CreateMap<Domain.Models.Customer, DataAccess.Entities.Customer>();
    }
}