﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Tvita_Test
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, string clientId)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message, clientId);
        }
    }
}