namespace NetHome.Common.Models.Devices
{
    public class RollerShutterModel : DeviceModel
    {
        public int CurrentPercentage { get; set; }
        public int FavPos1 { get; set; }
        public int FavPos2 { get; set; }
        public int FavPos3 { get; set; }
        public int FavPos4 { get; set; }
    }
}