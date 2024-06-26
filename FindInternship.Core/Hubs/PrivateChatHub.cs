﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FindInternship.Core.Hubs
{
    public class PrivateChatHub : Hub
    {
        private readonly IPrivateChatService privateChatService;
        private readonly IGroupService groupService;

        public PrivateChatHub(IPrivateChatService privateChatService, IGroupService groupService)
        {
            this.privateChatService = privateChatService;
            this.groupService = groupService;
        }

        public async Task AddToGroup(string groupName, string toUsername, string fromUsername)
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
            await groupService.AddUserToGroup(groupName, toUsername, fromUsername);
        }

        public async Task SendMessage(string fromUsername, string toUserName, string message, string group)
        {
            await privateChatService.SendMessageToUser(fromUsername, toUserName, message, group);

        }

        public async Task ReceiveMessage(string fromUsername, string message, string group)
        {
            await privateChatService.ReceiveNewMessage(fromUsername, message, group);
        }
    }
}
