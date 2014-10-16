using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.Dto.Topic
{
    public class DTOAddTopicResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public Guid? UserGuid { get; set; }
        public DateTime? CreationDateTime { get; set; }
    }
}
