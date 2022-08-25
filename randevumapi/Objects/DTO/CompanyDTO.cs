using Repository.EntitiyModels;
namespace RandevumAPI.Objects.DTO
{
    public class CompanyDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string PictureUrl { get; set; }
        public Phone PhoneNumber { get; set; }
        public Address Address { get; set; }

    }
}