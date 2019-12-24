using Application.Dto.Message;
using DataAccess;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppAsp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(MessageJsToHub message) =>
            await Clients.All.SendAsync("receiveMessage", message);

    }
}
