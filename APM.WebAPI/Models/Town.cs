namespace APM.WebAPI.Models
{
    public class Town
    {        
        public int Id { get; set; }
        public string Name { get; set; }        
        public Country Country { get; set; }
    }
}