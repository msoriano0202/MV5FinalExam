using Foro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.DataAccess
{
    public class DATopic
    {
        private readonly ForoContext _dbContext;

        public DATopic()
	    {
            _dbContext = new ForoContext();
	    }

        public IEnumerable<BETopic> ListTopics()
        {
            return _dbContext.Topics;
        }

        public BETopic GetTopicById(int id)
        {
            return _dbContext.Topics.Where(t => t.Id == id).FirstOrDefault();
        }

        public BETopic AddTopic(BETopic beTopic)
        {
            var newBETopic = _dbContext.Topics.Add(beTopic);
            _dbContext.SaveChanges();

            return newBETopic;
        }

    }
}
