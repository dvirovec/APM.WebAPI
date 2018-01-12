using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APM.WebAPI.Models
{
    public class Address
    {
        public int Id {get; set;}
        public string Street { get; set; }
        public Town Town { get; set; }
        public GeoLocation GetLocation {get; set;}

}
}