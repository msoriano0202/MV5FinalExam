using Foro.DataAccess;
using Foro.Dto.Topic;
using Foro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.Business
{
    public class TopicBusiness
    {
        private readonly DATopic _daTopic;

        public TopicBusiness()
        {
            _daTopic = new DATopic();
        }

        public IEnumerable<DTOAddTopicResponse> ListTopics() 
        {
            var beTopics = _daTopic.ListTopics().ToList();

            IEnumerable<DTOAddTopicResponse> result = beTopics.ConvertAll(t => new DTOAddTopicResponse() { 
                                                                                Id = t.Id,
                                                                                Title = t.Title,
                                                                                Description = t.Description,
                                                                                UserName = t.UserName,
                                                                                UserGuid = t.UserGuid,
                                                                                CreationDateTime = t.CreationDateTime
                                                                        });

            return result;
        }

        public DTOAddTopicResponse GetTopicById(int id)
        {
            var beTopic = _daTopic.ListTopics().Where(t => t.Id == id).FirstOrDefault();

            DTOAddTopicResponse result = new DTOAddTopicResponse()
            {
                Id = beTopic.Id,
                Title = beTopic.Title,
                Description = beTopic.Description,
                UserName = beTopic.UserName,
                UserGuid = beTopic.UserGuid,
                CreationDateTime = beTopic.CreationDateTime
            };

            return result;
        }

        public DTOAddTopicResponse AddTopic(DTOAddTopicRequest request) 
        {
            BETopic beTopic = new BETopic();
            beTopic.Title = request.Title;
            beTopic.Description = request.Description;
            beTopic.UserName = request.UserName;
            beTopic.UserGuid = request.UserGuid;
            beTopic.CreationDateTime = System.DateTime.Now;

            BETopic newBETopic = _daTopic.AddTopic(beTopic);

            DTOAddTopicResponse response = new DTOAddTopicResponse();
            response.Id = newBETopic.Id;
            response.Title = newBETopic.Title;
            response.Description = newBETopic.Description;
            response.UserName = newBETopic.UserName;
            response.UserGuid = newBETopic.UserGuid;
            response.CreationDateTime = newBETopic.CreationDateTime;

            return response;
        }

    }
}
