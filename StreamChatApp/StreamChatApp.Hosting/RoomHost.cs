using StreamChatApp.Communication.ServerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace StreamChatApp.Hosting
{
    public class RoomHost : IRoomHost
    {
        private ServiceHost host;
        private IRoomService roomService;

        public RoomHost(IRoomService roomService)
        {
            roomService = this.roomService;
        }

        public void StartRoom(int port)
        {
            string httpAddr = "http://localhost:" + port.ToString() + "/RoomService";
            string tcpAddr = "net.tcp://localhost:" + port.ToString() + "/RoomService";
            try
            {
                Uri httpUri = new Uri(httpAddr);
                Uri tcpUri = new Uri(tcpAddr);
                host = new ServiceHost(roomService, httpUri, tcpUri);

                ServiceMetadataBehavior mBehave = new ServiceMetadataBehavior();
                host.Description.Behaviors.Add(mBehave);
                host.AddServiceEndpoint(typeof(IMetadataExchange),
                  MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

                BasicHttpBinding httpb = new BasicHttpBinding();
                NetTcpBinding tcpb = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IRoomService), httpb, httpAddr);
                host.AddServiceEndpoint(typeof(IRoomService), tcpb, tcpAddr);
                host.Open();
            }
            catch (Exception e)
            { }
        }

        public void StopRoom()
        {
            try
            {
                host.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
