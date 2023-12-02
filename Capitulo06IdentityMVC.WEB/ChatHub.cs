using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitulo06IdentityMVC.WEB
{
    public class ChatHub : Hub
    {
        //public void Send(string name, string message)
        //{
        //    // Call the addNewMessageToPage method to update clients.
        //    Clients.All.addNewMessageToPage(name, message);
        //}        

        public void JoinGroup(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }

        public void LeaveGroup(string groupName)
        {
            Groups.Remove(Context.ConnectionId, groupName);
        }

        public void SendToGroup(string groupName, string name, string message)
        {
            Clients.Group(groupName).addNewMessageToPage(name, message);
        
        }
    }
}