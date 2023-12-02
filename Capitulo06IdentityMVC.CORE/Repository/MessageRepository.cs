using Capitulo06IdentityMVC.CORE.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo06IdentityMVC.CORE.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDbConnection _dbConnection;

        public MessageRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InsertMessage(Message message)
        {
            var query = "INSERT INTO Messages (UserName, GroupName, Content) VALUES (@UserName,@GroupName,@Content)";
            _dbConnection.Execute(query, new
            {
                message.UserName,
                message.GroupName,
                message.Content
            });
        }

        public IEnumerable<Message> GetGroupMessages(string groupName)
        {
            var query = "SELECT  *  FROM Messages WHERE GroupName = @GroupName";
            return _dbConnection.Query<Message>(query, new { GroupName = groupName });
        }
    }
}
