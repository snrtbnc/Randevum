using RandevumAPI.Objects;

namespace Repository.EntitiyModels
{
    [BsonCollection("company")]
    public class Company : Document
    {
        public string PictureUrl { get; set; }
        public string Name { get; set; }

        public string  ShortDesc { get; set; }
        
        public Phone PhoneNumber { get; set; }

        public Address Address { get; set; }
    }
}