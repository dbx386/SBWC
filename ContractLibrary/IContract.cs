using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Contract
{

   [ServiceContract(CallbackContract = typeof(IReturner))]
   public interface IContract
    {
       [OperationContract]
       public bool Subscribe();

    }
}
