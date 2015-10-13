using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;



namespace Host
{
   public class UserGroup
    {
        public int Id { get; set; }
        public List<User> UserList { get; set; }
    }
   public class ActiveGame
    {
        public int Id { get; set; }
        public UserGroup userGroup { get; set; }
    }
   public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IGameContractReturner Returner { get; set; }
    }

    public class ClientsDB
    {
        public List<User> users = new List<User>();
        public List<UserGroup> UserGroupList = new List<UserGroup>();
        public List<ActiveGame> ActiveGameList = new List<ActiveGame>();
    }

    class GameServerLogic : IGameServerContract
    {
        public List<User> Subscribe(string name)
        {
            Guid gd = new Guid(name);
            User user = new User();
            user.Id = gd.ToString();
            user.Name = name;
            user.Returner = OperationContext.Current.GetCallbackChannel<IGameContractReturner>();

            throw new NotImplementedException();
        }

        public bool Connect(UserGroup userGroup)
        {
           
            return true;           
        }

        public bool Disconnect(string UserName)
        {
            
            return true;
        }

        public void StartGame(object activeGame)
        {
            
            throw new NotImplementedException();
        }

        public void GameCommand()
        {
            throw new NotImplementedException();
        }

        public bool Connect(Contracts.UserGroup userGroup)
        {
            throw new NotImplementedException();
        }



        bool IGameServerContract.Subscribe(string name)
        {
            throw new NotImplementedException();
        }
    }


    class GameServer
    {
       static ServiceHost GameHost;
        static ClientsDB clDb;
        static void Main(string[] args)
        {
            clDb = new ClientsDB();
            GameHost = new ServiceHost(typeof(GameServerLogic), new Uri[] { });
            GameHost.AddServiceEndpoint(typeof(IGameServerContract), new NetTcpBinding(SecurityMode.None), "net.tcp://127.0.0.1:12876/callback");
            GameHost.Open();
            TicTacToeGame game = new TicTacToeGame();
            Console.ReadKey();                                                
        }
    }
}
