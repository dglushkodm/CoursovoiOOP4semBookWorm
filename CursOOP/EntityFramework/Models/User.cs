using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    public class User : Base
    {

        private string _username;
        public string Username { get { return _username; } set { _username = value; } }

        private byte[] _profileImage;
        public byte[] ProfileImage { get { return _profileImage; } set { _profileImage = value; } }
        

        private string _email;
        public string Email { get { return _email; } set { _email = value; } }
        
        private string _password;
        public string Password { get { return _password; } set { _password = value; } }
        
        [DefaultValue(0)]
        private ROLES _role;
        public ROLES Role { get { return _role; } set { _role = value; } }

        public bool CheckPassword(string suggestedPassord)
        {
            return BCrypt.Net.BCrypt.Verify(suggestedPassord, _password);
        }
        
        
        public User() { }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
    
    }
}