using Foro.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Foro.Mvc.Helpers
{
    public class UserApiHelper
    {
        private HttpClient client;
        private const string apiURL = "http://localhost:30882/";

        private HttpClient GetHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(apiURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public async Task<bool> AddUser( string userName, Guid userGuid) 
        {
            bool result = false;

            using (var client = GetHttpClient())
            {
                var userDTO = new DTOUserRequest() { UserName = userName , UserGuid = userGuid };
                var response = await client.PostAsJsonAsync("api/user", userDTO);
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
            }

            return result;
        }

        public async Task<DTOUserResponse> GetUserDTOByUserGuidAsync(Guid userGuid)
        {
            DTOUserResponse userDto = new DTOUserResponse();

            using (var client = GetHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(string.Format("api/user/{0}", userGuid));
                if (response.IsSuccessStatusCode)
                {
                    userDto = await response.Content.ReadAsAsync<DTOUserResponse>();
                }
            }

            return userDto;
        }

    }
}