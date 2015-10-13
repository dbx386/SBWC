using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using Contracts;



namespace Client
{
    /// <summary>
    /// Interaction logic for ClientUI.xaml
    /// </summary>
    public partial class ClientUI : Window
    {
        DuplexChannelFactory<IGameServerContract> TFactory;
        IGameServerContract services = null;
        public static TextBox tBox;

        public ClientUI()
        {
            this.Name = "Клиент";
            InitializeComponent();
            tBox = new TextBox();
            tBox.Width = statusBar.Width;
            tBox.Height = statusBar.Height;
            tBox.IsReadOnly = true;
            statusBar.Items.Add(tBox);

            TFactory = new DuplexChannelFactory<IGameServerContract>(new InstanceContext((object)(new GameClientLogic())), new NetTcpBinding(SecurityMode.None));
            services = TFactory.CreateChannel(new EndpointAddress("net.tcp://127.0.0.1:12876/callback"));
           
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            //services.Connect();
            
        }
    }
    /// <summary>
    /// Методы класса ReferralToServer использует сервер для получения данных от клиента
    /// </summary>
    class GameClientLogic : IGameContractReturner
    {

        public void ServerToClient(string txt)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllClients()
        {
            throw new NotImplementedException();
        }
    }
}
