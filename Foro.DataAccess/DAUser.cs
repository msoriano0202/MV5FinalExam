using Foro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.DataAccess
{
    public class DAUser
    {
        private readonly ForoContext _dbContext;

        public DAUser()
	    {
            _dbContext = new ForoContext();
	    }

        public IEnumerable<BEUser> ListUsers()
        {
            return _dbContext.Users;
        }

        public BEUser GetUserByGuid(Guid guid)
        {
            return _dbContext.Users.Where(t => t.UserGuid == guid).FirstOrDefault();
        }

        public BEUser GetUserById(int id)
        {
            return _dbContext.Users.Where(t => t.Id == id).FirstOrDefault();
        }

        public BEUser GetUserByUserName(string userName)
        {
            return _dbContext.Users.Where(t => t.UserName == userName).FirstOrDefault();
        }

        public BEUser AddUser(BEUser beUser)
        {
            var newBEUser = _dbContext.Users.Add(beUser);
            _dbContext.SaveChanges();

            return newBEUser;
        }

    }
}
