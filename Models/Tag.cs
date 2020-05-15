﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CompanyTag> CompanyTags { get; set; }
        public Tag()
        {
            CompanyTags = new List<CompanyTag>();
        }
    }
}
