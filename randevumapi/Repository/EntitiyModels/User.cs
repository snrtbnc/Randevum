using System;
using System.Text.Json.Serialization;

namespace Repository.EntitiyModels
{
    [BsonCollection("User")]
    public class User : Document
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}