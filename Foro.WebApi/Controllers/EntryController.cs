using Foro.Business;
using Foro.Dto.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Foro.WebApi.Controllers
{
    public class EntryController : ApiController
    {
        private readonly EntryBusiness _entryBusiness;

        public EntryController()
        {
            _entryBusiness = new EntryBusiness();
        }

        public IEnumerable<DTOEntryResponse> Get(int id)
        {
            var topics = _entryBusiness.ListEntries(id).ToList();

            return topics;
        }

        public void Post(DTOEntryRequest request)
        {
            _entryBusiness.AddEntry(request);
        }

    }
}
