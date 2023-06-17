using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AccountService
    {
        private CmsDbContext _dbContext;
        public AccountService(CmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUser(string email)
        {
            return _dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public void UpdateUser(User user) 
        { 
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges(); 
        }

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
