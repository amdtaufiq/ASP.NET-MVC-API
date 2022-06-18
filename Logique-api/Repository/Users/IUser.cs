using Logique_api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logique_api.Repository.Users
{
    interface IUser<T>
    {
        Task<List<T>> GetAll();
        Task Add(T user);
        Task<bool> Login(LoginRequest loginRequest);
        Task<bool> Logout(Guid userId);
    }
}