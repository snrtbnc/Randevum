namespace RandevumAPI.Objects.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public int LoginType { get; set; }

        public string LoginTypeToken { get; set; }
    }
}