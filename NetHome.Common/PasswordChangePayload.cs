using System;
using System.Collections.Generic;
using System.Text;

namespace NetHome.Common
{
    public class PasswordChangePayload
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
