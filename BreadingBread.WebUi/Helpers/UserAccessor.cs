﻿using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BreadingBread.WebUi.Helpers
{
    public class UserAccessor : IUserAccessor
    {
        public UserAccessor(IHttpContextAccessor accessor)
        {
            var claims = accessor.HttpContext?.User?.Claims?.ToList() ?? new List<Claim>();

            if (claims.Count > 0)
            {
                UserId = int.Parse(claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            }

            string role = claims.Where(el => el.Type == ClaimTypes.Role).Select(el => el.Value).SingleOrDefault();
            if (role != null)
            {
                if (Enum.TryParse(role, out UserType tipo))
                {
                    TipoUsuario = tipo;
                    IsAuthenticated = true;
                }
                else
                {
                    throw new InvalidCastException("El usuario no tiene ningun rol valido");
                }
            }
        }

        public int UserId { get; }

        public UserType TipoUsuario { get; }

        public bool IsAuthenticated { get; }
    }
}
