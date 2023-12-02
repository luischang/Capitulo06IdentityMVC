using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo06IdentityMVC.CORE.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public string Content { get; set; }
    }
}
