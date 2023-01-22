using Microsoft.AspNetCore.SignalR.Client;

var connection=new HubConnectionBuilder()
    .WithUrl("https://localhost:5001/chathub")
    .Build();


connection.StartAsync().Wait();

// SETTING
// sending to the server via the server/hub method
//await connection.InvokeCoreAsync("SendMessage",args: new[]
//{
//    "User0","Hello"
//});

// RETRIEVING
// getting the response
//connection.On("ReceiveMessage", (string user, string message)=>{
//    Console.WriteLine(user+" : "+message);
//});

// the code bellow doesn't work because its calling the string method before the server method is called with connection.InvokeAsync()
//connection.On("TestCall", x =>
//{
//    Console.WriteLine(x);
//});


Console.WriteLine("Enter username: \n");
var name = Console.ReadLine();
Console.WriteLine("Your user name is: " + name);
Console.WriteLine("----------------------------------------------------------------------------------");

while (true)
{
    Console.WriteLine("Enter message: \n");
    var text = Console.ReadLine();
    await connection.InvokeAsync("MethodWriteConsole", name + " : " + text);
}
