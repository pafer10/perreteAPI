using System.Diagnostics.Metrics;

namespace Perrete.API.Meters
{
    public static class PerreteMeter
    {
        public static Meter Meter = new Meter(OTELConfiguration.Name);

        public static Counter<int> Create = Meter.CreateCounter<int>("perrete.create");
        public static Counter<int> Update = Meter.CreateCounter<int>("perrete.update");
        public static Counter<int> Read = Meter.CreateCounter<int>("perrete.read");
    }
}
