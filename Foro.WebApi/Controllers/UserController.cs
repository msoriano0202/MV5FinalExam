using Foro.Business;
using Foro.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Foro.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserBusiness _userBusiness;

        public UserController()
        {
            _userBusiness = new UserBusiness();
        }

        public IEnumerable<DTOUserResponse> Get()
        {
            var users = _userBusiness.ListUsers().ToList();

            return users;
        }

        //public DTOUserResponse Get(int id)
        //{
        //    var user = _userBusiness.GetUserById(id);

        //    return user;
        //}

        public DTOUserResponse Get(Guid id)
        {
            var user = _userBusiness.GetUserByGuid(id);

            return user;
        }

        public void Post(DTOUserRequest request)
        {
            _userBusiness.AddUser(request);
        }
    }
}
