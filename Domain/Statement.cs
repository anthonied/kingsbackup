using System;
using System.Collections.Generic;

namespace Liquid.Domain
{
    public class Statement
    {
        public List<Client> Clients { get; set; }
        public Company Company { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }       
    }
}
