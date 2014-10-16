using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.Entity
{
    public class BETopicSubscription
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
