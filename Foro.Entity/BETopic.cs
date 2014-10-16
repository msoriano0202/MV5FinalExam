using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.Entity
{
    public class BETopic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public Guid? UserGuid { get; set; }
        public DateTime? CreationDateTime { get; set; }

        public IEnumerable<BEEntry> Entries { get; set; }
    }
}
