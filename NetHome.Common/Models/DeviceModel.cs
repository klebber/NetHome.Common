namespace NetHome.Common
{
    public abstract class DeviceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Room { get; set; }
        public string Type { get; set; }
    }
}