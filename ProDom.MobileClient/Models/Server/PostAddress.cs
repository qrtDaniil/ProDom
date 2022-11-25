using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models.Server
{
    public class PostAddress
    {
        public string? Index { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string House { get; set; }

        public int Entrance { get; set; }

        public int Apartment { get; set; }
    }

}
