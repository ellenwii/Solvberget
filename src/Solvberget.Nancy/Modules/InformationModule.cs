﻿using System.Collections.Generic;
using System.Linq;
using Nancy;
using Solvberget.Core.DTOs;
using Solvberget.Domain.Info;

namespace Solvberget.Nancy.Modules
{
    public class InformationModule : NancyModule
    {
        public InformationModule(IInformationRepository informationRepository) : base("/info")
        {
            Get["/contact"] = _ =>
            {
                var results = informationRepository.GetContactInformation();
                return results.Select(ci => new ContactInfoDto
                {
                    Address = ci.Address,
                    Email = ci.Email,
                    Fax = ci.Fax,
                    Phone = ci.Phone,
                    Title = ci.Title,
                    VisitingAddress = ci.VisitingAddress,
                    ContactPersons = MapContactPersons(ci.ContactPersons),
                    GenericFields = ci.GenericFields
                });
            };

            Get["/opening-hours"] = _ =>
            {
                var results = informationRepository.GetOpeningHoursInformation();
                return results.Select(oh => new OpeningHoursDto
                {
                    Title = oh.Title,
                    Hours = null != oh.LocationOrDayOfWeekToTime ? oh.LocationOrDayOfWeekToTime.Select(kvp => new OpeningHourInfoDto{Title = kvp.Key, Hours = kvp.Value}).ToArray() : new OpeningHourInfoDto[0],
                    Phone = oh.Phone,
                    Location = oh.Location,
                    SubTitle = oh.SubTitle,
                    Url = oh.Url,
                    UrlText = oh.UrlText
                });
            };
        }

        private static IEnumerable<ContactPersonDto> MapContactPersons(IEnumerable<ContactPerson> contactPersons)
        {
            if (contactPersons == null)
                return Enumerable.Empty<ContactPersonDto>();

            return contactPersons.Select(cp => new ContactPersonDto
            {
                Email = cp.Email,
                Name = cp.Name,
                Phone = cp.Phone,
                Position = cp.Position
            });
        }
    }
}