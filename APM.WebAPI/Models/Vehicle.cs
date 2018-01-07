using System.ComponentModel.DataAnnotations;

namespace APM.WebAPI.Models
{
    public class Vehicle
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Personal { get; set; }
    }
}