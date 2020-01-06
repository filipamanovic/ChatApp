using Application.Commands.User;
using Application.Dto.Message;
using Application.Dto.User;
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

        public async Task SendProfile(UserDisplay profileUpdate) =>
            await Clients.Others.SendAsync("receiveProfile", profileUpdate);
    }
}
