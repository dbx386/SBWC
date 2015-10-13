using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts
{
    public class ActiveGame
    {
        public int Id { get; set; }
        public UserGroup userGroup { get; set; }
    }
}
