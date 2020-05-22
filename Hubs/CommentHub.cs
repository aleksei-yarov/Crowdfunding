using Crowdfunding.Data;
using Crowdfunding.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Hubs
{
    public class CommentHub: Hub
    {
        private readonly ApplicationDbContext _context;
        public CommentHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Send(string message, string userName, string companyId, string dateTime)
        {
            Comment newComment = new Comment { CompanyId = int.Parse(companyId), 
                Message = message, UserName = userName, Date=dateTime};
            await _context.AddAsync(newComment);
            await _context.SaveChangesAsync();
            await this.Clients.All.SendAsync("Send", message, userName, companyId, dateTime);
        }
    }
}
