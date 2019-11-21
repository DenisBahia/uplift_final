using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class UserRepository : Repository<ApplicationUser> , IUserRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void LockUser(string userId)
        {
            var userFromDB = _dbContext.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            userFromDB.LockoutEnd = DateTime.Now.AddYears(1000);
            _dbContext.SaveChanges();
        }

        public void UnlockUser(string userId)
        {
            var userFromDB = _dbContext.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            userFromDB.LockoutEnd = DateTime.Now;
            _dbContext.SaveChanges();
        }
    }
}
