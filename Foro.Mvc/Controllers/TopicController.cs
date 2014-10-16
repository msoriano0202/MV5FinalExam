using Foro.Dto.Topic;
using Foro.Dto.Entry;
using Foro.Mvc.Models.Topics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Foro.Mvc.Helpers;
using Foro.Dto.User;

namespace Foro.Mvc.Controllers
{
    public class TopicController : Controller
    {
        private HttpClient client;
        private const string apiURL = "http://localhost:30882/";
        private UserApiHelper userApiHelper = new UserApiHelper();

        public TopicController()
        { }

        private async Task<DTOUserResponse> GetUserDTO() 
        {
            string userId = User.Identity.GetUserId();
            Guid userGuid = new Guid(userId);
            return await userApiHelper.GetUserDTOByUserGuidAsync(userGuid);
        }

        private HttpClient GetHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(apiURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        async Task<List<DTOAddTopicResponse>> GetTopicsDTOAsync()
        {
            List<DTOAddTopicResponse> listTopicDTO = new List<DTOAddTopicResponse>();

            using (var client = GetHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/topic");
                if (response.IsSuccessStatusCode)
                {
                    string topicsJson = await response.Content.ReadAsStringAsync();

                    var topicsDTODeserialzed = JsonConvert.DeserializeObject<List<DTOAddTopicResponse>>(topicsJson);
                    if (topicsDTODeserialzed.Count() > 0)
                    {
                        listTopicDTO.AddRange(topicsDTODeserialzed);
                    }
                }
            }

            return listTopicDTO;
        }

        async Task<DTOAddTopicResponse> GetTopicDTOAsync(int id)
        {
            DTOAddTopicResponse topicDto = new DTOAddTopicResponse();

            using (var client = GetHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(string.Format("api/topic/{0}", id.ToString()));
                if (response.IsSuccessStatusCode)
                {
                    topicDto = await response.Content.ReadAsAsync<DTOAddTopicResponse>();                   
                }
            }

            return topicDto;
        }

        async Task<List<DTOEntryResponse>> GetEntriesDTOAsync(int topicId)
        {
            List<DTOEntryResponse> listEntryDTO = new List<DTOEntryResponse>();

            using (var client = GetHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(string.Format("api/entry/{0}", topicId.ToString()));
                if (response.IsSuccessStatusCode)
                {
                    string entriesJson = await response.Content.ReadAsStringAsync();

                    var entriesDTODeserialzed = JsonConvert.DeserializeObject<List<DTOEntryResponse>>(entriesJson);
                    if (entriesDTODeserialzed.Count() > 0)
                    {
                        listEntryDTO.AddRange(entriesDTODeserialzed);
                    }
                }
            }

            return listEntryDTO;
        }

        private void SubscribeUserToNotifications() 
        { }

        public async Task<ActionResult> Index()
        {
            var result = await GetTopicsDTOAsync();

            var model = result.ConvertAll(t => new TopicShortViewModel() { 
                                                Id = t.Id,
                                                Title = t.Title,
                                                ShortDescription = string.Format("{0} ... ", t.Description.Substring(0, t.Description.Length > 500 ? 500 : t.Description.Length)),
                                                UserName = t.UserName,
                                                CreationDateTime = t.CreationDateTime.GetValueOrDefault(),
                                                CreationDateTimeString = t.CreationDateTime.GetValueOrDefault().ToString("dd MMM yyyy")
                                            });

            return View(model);
        }

        public async Task<ActionResult> Detail(int id) 
        {
            var result = await GetTopicDTOAsync(id);
            var resultEntries = await GetEntriesDTOAsync(id);

            var model = new TopicDetailViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                UserName = result.UserName,
                CreationDateTimeString = result.CreationDateTime.GetValueOrDefault().ToString("dd MMM yyyy"),
                Entries = resultEntries.ConvertAll(r => new EntryDetailViewModel() { Id = r.Id, Comment = r.Comment, UserName = r.UserName, CreationDateTimeString = r.CreationDateTime.GetValueOrDefault().ToString("dd MMM yyyy") })
            };

            return View(model);
        }

        public ActionResult Create()
        {
            TopicAddViewModel model = new TopicAddViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TopicAddViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userDTO = await GetUserDTO();

                    using (var client = GetHttpClient())
                    {
                        var topicDTO = new DTOAddTopicRequest() { Title = model.Title, Description = model.Description, UserName = userDTO.UserName };
                        var response = await client.PostAsJsonAsync("api/topic", topicDTO);
                        if (response.IsSuccessStatusCode)
                        {
                            // Get the URI of the created resource.
                            //Uri gizmoUrl = response.Headers.Location;

                            return RedirectToAction("Index");
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEntry(int TopicId, string EntryComent) 
        {
            if(TopicId > 0 && !string.IsNullOrEmpty(EntryComent))
            {
                var userDTO = await GetUserDTO();

                using (var client = GetHttpClient())
                {
                    var entryDTO = new DTOEntryRequest() { TopicId = TopicId, Comment = EntryComent, UserName = userDTO.UserName };
                    var response = await client.PostAsJsonAsync("api/entry", entryDTO);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Detail", new { id = TopicId });
                    }
                }
            }

            return RedirectToAction("Detail", new { id = TopicId });
        }

    }
}