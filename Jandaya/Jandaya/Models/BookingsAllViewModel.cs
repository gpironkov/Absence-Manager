namespace Jandaya.Models
{
    using AutoMapper;
    using Jandaya.Data.Models;
    using Jandaya.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class BookingsAllViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string BookingType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Duration { get; set; }

        public string Status { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Booking, BookingsAllViewModel>()
                .ForMember(
                    u => u.UserName,
                    opt => opt.MapFrom(u => $"{u.User.UserName}"))
                .ForMember(
                    bt => bt.BookingType,
                    opt => opt.MapFrom(bt => $"{bt.BookingType.Name}"))
                .ForMember(
                    s => s.Status,
                    opt => opt.MapFrom(s => $"{s.Status}"));
        }
    }
}
