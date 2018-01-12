using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APM.WebAPI.Models
{
    public class Company
    {

    public int Id {get; set;}
    public string Name { get; set; }
    public string Code { get; set; }
    public Address Address { get; set; }



    }
}