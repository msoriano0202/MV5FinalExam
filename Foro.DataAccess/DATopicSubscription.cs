using Foro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foro.DataAccess
{
    public class DATopicSubscription
    {
        private readonly ForoContext _dbContext;

        public DATopicSubscription()
        {
            _dbContext = new ForoContext();
        }

        public IEnumerable<BETopicSubscription> ListTopicSubcriptions(int id)
        {
            return _dbContext.TopicSubscription.Where(s => s.TopicId == id).ToList();
        }

        public BETopicSubscription AddTopicSubscription(BETopicSubscription beTopicSubscription)
        {
            var newBETopicSubscription = _dbContext.TopicSubscription.Add(beTopicSubscription);
            _dbContext.SaveChanges();

            return newBETopicSubscription;
        }
    }
}
