using System;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.IRepositories;
using Logic;

namespace DataAccess.Repositories {
    public class MessageRepository : RepositoryBase<SdDb>, IMessageRepository {
        public Message GetMessage(int id) {
            return GetMessage(message => message.Id == id);
        }

        public Message GetMessage(Expression<Func<Message, bool>> wherePredicate) {
            return Get(wherePredicate);
        }

        public IQueryable<Message> Messages {
            get { return GetAll<Message>(); }
        }

        public IQueryable<Message> GetMessages<TKey>(Expression<Func<Message, TKey>> orderByPredicate) {
            return GetAllOrderedBy(orderByPredicate);
        }

        public OperationStatus<Message> AddMessage(Message message) {
            return Add(message);
        }

        public OperationStatus<Message> UpdateMessage(Message message) {
            return InsertOrUpdate(message);
        }
    }
}
