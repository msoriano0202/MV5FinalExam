using Foro.Business;
using Foro.Dto.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Foro.WebApi.Controllers
{
    //Install-Package Microsoft.AspNet.WebApi.Cors
    //[EnableCors(origins: "http://localhost:30884", headers: "*", methods: "*")]
    public class TopicController : ApiController
    {
        private readonly TopicBusiness _topicBusiness;

        public TopicController()
        {
            _topicBusiness = new TopicBusiness();
        }

        public IEnumerable<DTOAddTopicResponse> Get()
        {
            var topics = _topicBusiness.ListTopics().ToList();

            return topics;
        }

        public DTOAddTopicResponse Get(int id)
        {
            var topic = _topicBusiness.GetTopicById(id);

            return topic;
        }

        public void Post(DTOAddTopicRequest request) 
        {
            _topicBusiness.AddTopic(request);
        }

    }
}
