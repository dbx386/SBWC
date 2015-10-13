using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Contract
{

    
    public interface IReturner
    {
    [OperationContract]
    void ServerToClient(string txt);

    }
}
