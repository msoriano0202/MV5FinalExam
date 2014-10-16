using Foro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.DataAccess
{
    public class DAEntry
    {
        private readonly ForoContext _dbContext;

        public DAEntry()
        {
            _dbContext = new ForoContext();
        }

        public IEnumerable<BEEntry> ListEntries()
        {
            return _dbContext.Entries;
        }

        public IEnumerable<BEEntry> ListEntriesByTopicId(int id)
        {
            return _dbContext.Entries.Where(e => e.TopicId == id).ToList();
        }

        public BEEntry GetEntryById(int id)
        {
            return _dbContext.Entries.Where(e => e.Id == id).FirstOrDefault();
        }

        public BEEntry AddEntry(BEEntry beEntry)
        {
            var newBEEntry = _dbContext.Entries.Add(beEntry);
            _dbContext.SaveChanges();

            return newBEEntry;
        }

    }
}
