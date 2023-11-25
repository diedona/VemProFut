using VemProFut.Domain.Entities.Bases;

namespace VemProFut.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public UserEntity(string username, string password) : base()
        {
            Username = username;
            Password = password;
        }
    }
}
