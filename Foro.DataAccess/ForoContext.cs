using Foro.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.DataAccess
{
    public class ForoContext : DbContext
    {
        public ForoContext()
            : base(nameOrConnectionString: "ForoConn")
        {
        }

        public DbSet<BEEntry> Entries { get; set; }
        public DbSet<BETopic> Topics { get; set; }
        public DbSet<BETopicSubscription> TopicSubscription { get; set; }
        public DbSet<BEUser> Users { get; set; }
    }
}
