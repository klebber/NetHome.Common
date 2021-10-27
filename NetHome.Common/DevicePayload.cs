using NetHome.Common.Models;

namespace NetHome.Common
{
    public class DevicePayload
    {
        public DeviceModel Device { get; set; }
        public string IpAdress { get; set; }
        public string DeviceUsername { get; set; }
        public string DevicePassword { get; set; }
    }
}