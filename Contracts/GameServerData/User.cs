using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts
{
    public class User
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public IGameContractReturner Returner { get; set; }
    }
}
