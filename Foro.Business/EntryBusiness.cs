using Foro.DataAccess;
using Foro.Dto.Entry;
using Foro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.Business
{
    public class EntryBusiness
    {
        private readonly DAEntry _daEntry;

        public EntryBusiness()
        {
            _daEntry = new DAEntry();
        }

        public IEnumerable<DTOEntryResponse> ListEntries(int topicId)
        {
            var beTopics = _daEntry.ListEntriesByTopicId(topicId).ToList();

            IEnumerable<DTOEntryResponse> result = beTopics.ConvertAll(t => new DTOEntryResponse()
            {
                Id = t.Id,
                Comment = t.Comment,
                UserName = t.UserName,
                UserGuid = t.UserGuid,
                CreationDateTime = t.CreationDateTime
            });

            return result;
        }

        public DTOEntryResponse AddEntry(DTOEntryRequest request)
        {
            BEEntry beEntry = new BEEntry();
            beEntry.TopicId = request.TopicId;
            beEntry.Comment = request.Comment;
            beEntry.UserName = request.UserName;
            beEntry.UserGuid = request.UserGuid.GetValueOrDefault();
            beEntry.CreationDateTime = System.DateTime.Now;

            BEEntry newBEEntry = _daEntry.AddEntry(beEntry);

            DTOEntryResponse response = new DTOEntryResponse();
            response.Id = newBEEntry.Id;
            response.TopicId = newBEEntry.TopicId;
            response.Comment = newBEEntry.Comment;
            response.UserName = newBEEntry.UserName;
            response.UserGuid = newBEEntry.UserGuid;
            response.CreationDateTime = newBEEntry.CreationDateTime;

            return response;
        }

    }
}
