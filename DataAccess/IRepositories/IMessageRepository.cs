using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Logic;

namespace DataAccess.IRepositories {
    public interface IMessageRepository : IBaseRepository{
        Message GetMessage(int id);
        Message GetMessage(Expression<Func<Message, bool>> wherePredicate);
        IQueryable<Message> Messages { get; }
        IQueryable<Message> GetMessages<TKey>(Expression<Func<Message, TKey>> orderByPedicate);
        OperationStatus<Message> AddMessage(Message message);
        OperationStatus<Message> UpdateMessage(Message message);
    }
}
