using NetHome.Common;

namespace NetHome.Common
{
    public class LoginResponse
    {
        public UserModel User { get; set; }
        public string Token { get; set; }
    }
}