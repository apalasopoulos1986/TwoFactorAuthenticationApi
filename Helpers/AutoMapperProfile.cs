﻿using AutoMapper;
using TwoFactorAuthenticationApi.DTOs;
using TwoFactorAuthenticationApi.Entities;
using TwoFactorAuthenticationApi.Models.Users;

namespace TwoFactorAuthenticationApi.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));

             //Create Contact
            CreateMap<ContactCreationRequestDTO, Contact>();

            //Update Contact
            CreateMap<ContactUpdateRequestDTO, Contact>()
               .ForAllMembers(x => x.Condition(
                   (src, dest, prop) =>
                   {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                       if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                       return true;
                   }
               ));

        }
    }
}
