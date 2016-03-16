using BloodMap.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodMap.Data.Context;


namespace BloodMap.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly BloodMapEntities _context;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountService()
        {
            _context = new BloodMapEntities();
        }

        /// <summary>
        /// Add User Details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        /// <summary>
        /// Delete User Details
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(int userId)
        {
            _context.Users.Remove(_context.Users.Where(where => where.UserId == userId).FirstOrDefault());
            _context.SaveChanges();
        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            return _context.Users.Where(where => where.UserId == id).FirstOrDefault();
        }

        /// <summary>
        /// Update User Details
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            var dbUser = _context.Users.Where(where => where.UserId == user.UserId).FirstOrDefault();
            if (dbUser != null)
            {
                dbUser.IsDonor = user.IsDonor;
                dbUser.Donors = user.Donors;
                dbUser.DOB = user.DOB;
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.Phone = user.Phone;
            }
        }

        /// <summary>
        /// Login Verification method
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Login VerifyLogin(string username, string password)
        {
            return _context.Logins.Where(where => where.EmailId == username && where.Password == password).FirstOrDefault();
        }

        /// <summary>
        /// Update Password Method
        /// </summary>
        /// <param name="login"></param>
        /// <param name="newPassword"></param>
        public void UpdatePassword(Login login, string newPassword)
        {
            var userLogin = _context.Logins.Where(where => where.EmailId == login.EmailId && where.Password == login.Password).FirstOrDefault();
            if (userLogin != null)
            {
                userLogin.Password = newPassword;
            }
        }

    }
}
