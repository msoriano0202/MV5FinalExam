using Foro.DataAccess;
using Foro.Dto.User;
using Foro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.Business
{
    public class UserBusiness
    {
        private readonly DAUser _daUser;

        public UserBusiness()
        {
            _daUser = new DAUser();
        }

        public IEnumerable<DTOUserResponse> ListUsers()
        {
            var beUsers = _daUser.ListUsers().ToList();

            IEnumerable<DTOUserResponse> result = beUsers.ConvertAll(t => new DTOUserResponse()
            {
                Id = t.Id,
                UserGuid = t.UserGuid,
                UserName = t.UserName,
                FirstName = t.FirstName,
                LastName = t.LastName
            });

            return result;
        }

        public DTOUserResponse GetUserById(int id)
        {
            var beUser = _daUser.GetUserById(id);

            DTOUserResponse result = new DTOUserResponse()
            {
                Id = beUser.Id,
                UserGuid = beUser.UserGuid,
                UserName = beUser.UserName,
                FirstName = beUser.FirstName,
                LastName = beUser.LastName
            };

            return result;
        }

        public DTOUserResponse GetUserByGuid(Guid guid)
        {
            var beUser = _daUser.GetUserByGuid(guid);

            DTOUserResponse result = new DTOUserResponse()
            {
                Id = beUser.Id,
                UserGuid = beUser.UserGuid,
                UserName = beUser.UserName,
                FirstName = beUser.FirstName,
                LastName = beUser.LastName
            };

            return result;
        }

        public DTOUserResponse GetUserByUserName(string userName)
        {
            var beUser = _daUser.GetUserByUserName(userName);

            DTOUserResponse result = new DTOUserResponse()
            {
                Id = beUser.Id,
                UserGuid = beUser.UserGuid,
                UserName = beUser.UserName,
                FirstName = beUser.FirstName,
                LastName = beUser.LastName
            };

            return result;
        }

        public DTOUserResponse AddUser(DTOUserRequest request)
        {
            BEUser beUser = new BEUser();
            beUser.UserGuid = request.UserGuid.GetValueOrDefault();
            beUser.UserName = request.UserName;
            beUser.FirstName = request.FirstName;
            beUser.LastName = request.LastName;

            BEUser newBEUser = _daUser.AddUser(beUser);

            DTOUserResponse response = new DTOUserResponse();
            response.Id = newBEUser.Id;
            response.UserGuid = newBEUser.UserGuid;
            response.UserName = newBEUser.UserName;
            response.FirstName = newBEUser.FirstName;
            response.LastName = newBEUser.LastName;

            return response;
        }

    }
}
