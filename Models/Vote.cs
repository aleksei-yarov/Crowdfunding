using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Username { get; set; }
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
