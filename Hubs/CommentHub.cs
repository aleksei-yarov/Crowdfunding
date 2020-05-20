using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Hubs
{
    public class CommentHub: Hub
    {
        public async Task Send(string comment, string userName, string companyId)
        {
            await this.Clients.All.SendAsync("Send", comment, userName, companyId);
        }
    }
}
