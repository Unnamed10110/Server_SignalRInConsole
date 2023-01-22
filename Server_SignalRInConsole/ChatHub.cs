using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_SignalRInConsole
{
    public class ChatHub:Hub //,IHostedService
    {
        private Timer _timer;
        public ChatHub()
        {

        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void MethodWriteConsole(string s)
        {
            Console.WriteLine(s);
        }

        
        public async Task ToAllClientsTest(string txt)
        {
            await Clients.All.SendAsync("TestCall",txt);
        }

        
        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    _timer = new Timer(CheckFromServer, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(10));

        //    return Task.CompletedTask;
        //}

        //private void CheckFromServer(object? state)
        //{
        //    var res = "-> Check from server <-";
        //    Clients.All.SendAsync("checking", res);
        //}

        //public Task StopAsync(CancellationToken cancellationToken)
        //{
        //    _timer.Change(Timeout.Infinite, 0);

        //    return Task.CompletedTask;
        //}
    }
}
