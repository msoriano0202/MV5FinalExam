using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.Entity
{
    public class BEEntry
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public Guid UserGuid { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
