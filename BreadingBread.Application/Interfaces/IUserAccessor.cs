﻿using BreadingBread.Domain.Enums;

namespace BreadingBread.Application.Interfaces
{
    public interface IUserAccessor
    {
        int UserId { get; }
        bool IsAuthenticated { get; }
        UserType TipoUsuario { get; }
    }
}
