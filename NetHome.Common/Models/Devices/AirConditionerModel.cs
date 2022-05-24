namespace NetHome.Common
{
    public class AirConditionerModel : DeviceModel
    {
        public bool Ison { get; set; }
        public int Temperature { get; set; }
        public int FanSpeed { get; set; }
        public bool Swing { get; set; }
        public bool TimerSet { get; set; }
        public double TimerValue { get; set; }
    }
}