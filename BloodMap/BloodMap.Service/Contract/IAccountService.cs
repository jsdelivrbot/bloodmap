﻿using BloodMap.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodMap.Service.Contract
{
    public interface IAccountService
    {
        User VerifyLogin(string username, string password);

        User GetUser(int id);

        int AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int userId);

        void UpdatePassword(int userId, string newPassword);
        void InsertSecurityToken(Re_Handshake input);

        User VerifyReHandshake(string key, string token);
    }
}
