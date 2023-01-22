using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using SignalR_PostComment.Models;
using System.IO;
namespace SignalR_PostComment.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class HubChatController : ControllerBase
    {
        

        public HubChatController()
        {
        }

        

        [HttpPost]
        public async Task SendMessage(Mensaje msg)
        {
            var connection = new HubConnectionBuilder()
                                    .WithUrl("https://localhost:5001/chathub")
                                    .Build();


            connection.StartAsync().Wait();

            await connection.InvokeAsync("SendMessage", msg.User, msg.Message);

            connection.On("ReceiveMessage", (string user, string message) => {

                //here goes the action on the client

            });

            await connection.InvokeAsync("MethodWriteConsole", msg.User+" : "+ msg.Message);
            Ok();
        }


       
    }
}