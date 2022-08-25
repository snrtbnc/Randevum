

namespace RandevumAPI.Objects
{
    public class Address
    {
        public string Country { get; set; }

        public Location Location {get;set;}
        public int CityCode { get; set; }

        public string CityName { get; set; }     

        public string District { get; set; }

        public string Detail { get; set; }


    }
}