using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foro.Mvc.Models.Topics
{
    public class TopicShortViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string CreationDateTimeString { get; set; }
    }
}