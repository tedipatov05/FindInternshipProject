using FindInternship.Core.Contracts;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Hubs
{
    public class RoomHub : Hub
    {
        private readonly IUserService userService;
        public RoomHub(IUserService userService)
        {
            this.userService = userService;
        }

        
    }
}
