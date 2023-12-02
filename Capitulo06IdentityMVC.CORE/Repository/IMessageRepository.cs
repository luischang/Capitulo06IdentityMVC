using Capitulo06IdentityMVC.CORE.Model;
using System.Collections.Generic;

namespace Capitulo06IdentityMVC.CORE.Repository
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetGroupMessages(string groupName);
        void InsertMessage(Message message);
    }
}