using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;




namespace Contracts
{    
   [ServiceContract(CallbackContract = typeof(IGameContractReturner))]
   public interface IGameServerContract
    {
       [OperationContract]
       bool Subscribe(string name);
       [OperationContract]
       bool Connect(UserGroup userGroup);
       [OperationContract]
       bool Disconnect(string UserName);
       [OperationContract]
       void StartGame(object activeGame);
       [OperationContract]
       void GameCommand();
    }
}
