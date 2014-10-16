using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foro.Mvc.Models.Topics
{
    public class TopicDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string CreationDateTimeString { get; set; }

        public IEnumerable<EntryDetailViewModel> Entries { get; set; }
    }

    public class EntryDetailViewModel 
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public string CreationDateTimeString { get; set; }
    }
}