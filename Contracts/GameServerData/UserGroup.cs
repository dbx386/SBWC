using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts
{
    public class UserGroup
    {
        public int Id { get; set; }
        public List<User> UserList { get; set; }
    }
}
